using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;

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
        /// <param name="optionsFactory">The factory to create options for the behavior of MemoryCache.</param>
        /// <returns>Return a cached version of the input function. Add an extra bool parameter to enable/disable the cache.</returns>
        public Func<T, bool, TResult> Create<T, TResult>(Func<T, TResult> func, Func<T, MemoryCacheEntryOptions> optionsFactory)
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
                    cache.Set(key, obj, optionsFactory?.Invoke(input));
                    return obj;
                }
                finally
                {
                    locks.TryRemove(input, out object o);
                    Monitor.Exit(lockObj);
                }
            };

            return cachedFunc;
        }
    }
}
