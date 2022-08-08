using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MagicEastern.CachedFunc2
{
    public class CachedFuncSvc
    {
        private static int _funcID = 0;

        private readonly IMemoryCache cache;

        public CachedFuncSvc(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        /// <summary>
        /// Create a cached version of the input function, the input function should be in this signature, Func<ValueTuple<>, TResult>. 
        /// Thus, it is not recommended to call this function directly. Call one of CachedFuncSvc's extension methods instead.
        /// </summary>
        /// <typeparam name="T">Should be one of ValueTuple<>. The maximun number of arguments of the ValueTuple is 7.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">The input function, should only contain one argument in Type T.</param>
        /// <param name="options">The options for the behavior of MemoryCache. 
        /// If the CacheItemPriority is NeverRemove, the cache will be reloaded immediately after it expires.</param>
        /// <returns>Return a cached version of the input function. Add an extra bool parameter to enable/disable the cache.</returns>
        public Func<T, bool, TResult> Create<T, TResult>(Func<T, TResult> func, MemoryCacheEntryOptions options = null)
            where T : IComparable, IComparable<T>, IEquatable<T>, IStructuralComparable, IStructuralEquatable
        {
            var funcID = Interlocked.Increment(ref _funcID);

            ConcurrentDictionary<T, object> locks = new ConcurrentDictionary<T, object>();

            Func<T, bool, TResult> cachedFunc = (input, nocache) =>
            {
                TResult obj;
                var key = new CacheKey<T>(funcID, input);
                if (!nocache && cache.TryGetValue(key, out obj))
                {
                    return obj;
                }

                object lockObj = locks.GetOrAdd(input, new object());
                Monitor.Enter(lockObj);
                try
                {
                    if (!nocache && cache.TryGetValue(key, out obj))
                    {
                        return obj;
                    }
                    obj = func(input);
                    cache.Set(key, obj, options);
                    return obj;
                }
                finally
                {
                    locks.TryRemove(input, out object o);
                    Monitor.Exit(lockObj);
                }
            };

            if (CacheItemPriority.NeverRemove.Equals(options?.Priority))
            {
                options.RegisterPostEvictionCallback((key, value, reason, state) =>
                {
                    /* 
                     * Add back the cache immediately, and call cachedFunc() with nocache = true,
                     * so that there is no downtime during getting the updated results for this cache.
                     */
                    cache.Set(key, value);
                    var ck = (CacheKey<T>)key;
                    _ = cachedFunc(ck.Key, true);
                });

                if (typeof(T) == typeof(ValueTuple))
                {
                    Task.Run(() =>
                    {
                        // the original function does not have any parameter. Eager load the cache.
                        _ = cachedFunc(default(T), true);
                    });
                }
            }

            return cachedFunc;
        }
    }
}
