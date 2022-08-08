namespace MagicEastern.CachedFunc2
{

    /// <summary>
    /// Represent a Cached Function that takes no parameter.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="nocache"></param>
    /// <returns></returns>
    public delegate TResult CachedFunc<TResult>(bool nocache = false);

    public delegate TResult CachedFunc<T1, TResult>(T1 arg1, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, TResult>(T1 arg1, T2 arg2, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, bool nocache = false);

    public delegate TResult CachedFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, bool nocache = false);

}
