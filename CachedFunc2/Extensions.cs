using Microsoft.Extensions.Caching.Memory;
using System;

namespace MagicEastern.CachedFunc2
{
    public static class Extensions
    {
        #region CachedFunc
        public static CachedFunc<TResult> Create<TResult>(
            this CachedFuncSvc svc
            , Func<TResult> func
            , Func<MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple, TResult> tupleFunc = (_) => func();
            var cachedTupleFunc = svc.Create(tupleFunc, (_) => optionsFactory?.Invoke());
            return (nocache) => cachedTupleFunc(default(ValueTuple), nocache);
        }

        public static CachedFunc<T, TResult> Create<T, TResult>(
            this CachedFuncSvc svc
            , Func<T, TResult> func
            , Func<T, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T>, TResult> tupleFunc = (args) => func(args.Item1);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1));
            return (arg1, nocache) => cachedTupleFunc(ValueTuple.Create(arg1), nocache);
        }

        public static CachedFunc<T1, T2, TResult> Create<T1, T2, TResult>(
            this CachedFuncSvc svc
            , Func<T1, T2, TResult> func
            , Func<T1, T2, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2));
            return (arg1, arg2, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2), nocache);
        }

        public static CachedFunc<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(
            this CachedFuncSvc svc
            , Func<T1, T2, T3, TResult> func
            , Func<T1, T2, T3, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2, T3>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2, args.Item3);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2, args.Item3));
            return (arg1, arg2, arg3, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2, arg3), nocache);
        }

        public static CachedFunc<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(
            this CachedFuncSvc svc
            , Func<T1, T2, T3, T4, TResult> func
            , Func<T1, T2, T3, T4, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2, T3, T4>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2, args.Item3, args.Item4);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2, args.Item3, args.Item4));
            return (arg1, arg2, arg3, arg4, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2, arg3, arg4), nocache);
        }

        public static CachedFunc<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5, TResult>(
            this CachedFuncSvc svc
            , Func<T1, T2, T3, T4, T5, TResult> func
            , Func<T1, T2, T3, T4, T5, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2, T3, T4, T5>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5));
            return (arg1, arg2, arg3, arg4, arg5, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5), nocache);
        }

        public static CachedFunc<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(
            this CachedFuncSvc svc
            , Func<T1, T2, T3, T4, T5, T6, TResult> func
            , Func<T1, T2, T3, T4, T5, T6, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2, T3, T4, T5, T6>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6));
            return (arg1, arg2, arg3, arg4, arg5, arg6, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5, arg6), nocache);
        }

        public static CachedFunc<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(
           this CachedFuncSvc svc
           , Func<T1, T2, T3, T4, T5, T6, T7, TResult> func
           , Func<T1, T2, T3, T4, T5, T6, T7, MemoryCacheEntryOptions> optionsFactory = null)
        {
            Func<ValueTuple<T1, T2, T3, T4, T5, T6, T7>, TResult> tupleFunc = (args) => func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6, args.Item7);
            var cachedTupleFunc = svc.Create(tupleFunc, (args) => optionsFactory?.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6, args.Item7));
            return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, nocache) => cachedTupleFunc(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5, arg6, arg7), nocache);
        }
        #endregion



    }
}
