using System;
using System.Collections;

namespace MagicEastern.CachedFunc2
{
    public struct CacheKey<T> : IEquatable<CacheKey<T>>
        where T : IComparable, IComparable<T>, IEquatable<T>, IStructuralComparable, IStructuralEquatable
    {
        public readonly int FuncID;
        public readonly T Key;

        public CacheKey(int funcID, T key)
        {
            FuncID = funcID;
            Key = key;
        }

        public bool Equals(CacheKey<T> other)
        {
            return Key.Equals(other.Key)
                && FuncID == other.FuncID;
        }

        public override bool Equals(object obj)
        {
            if (obj is CacheKey<T> ck)
            {
                return Equals(ck);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key, FuncID);
        }
    }
}
