using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WebLab1_Levchenko.Tests
{
    class Comparer<T>:IEqualityComparer<T>
    {
        public static Comparer<T> GetComparer (Func<T, T, bool> func)
        {
            return new Comparer<T>(func); 
        }
        Func<T, T, bool> compareFunction;

        public Comparer(Func<T, T, bool> func)
        {
            compareFunction = func;
        }
        public bool Equals(T x, T y)
        {
            return compareFunction(x, y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            throw new NotImplementedException();
        }

    }
}
