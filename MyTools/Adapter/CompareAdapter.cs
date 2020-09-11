using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Adapter
{
    /// <summary>
    /// Хороший пример адаптора. Он делегирует вызов делегата CompDelegate через интерфейс IComparer<typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompareAdapter<T> : IComparer<T>
    {
        public int Number;
        public delegate int CompDelegate(T a, T b);
        CompDelegate comparator;

        private CompareAdapter()
        {

        }

        public CompareAdapter(CompDelegate comparator)
        {
            this.comparator += comparator;
        }

        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            //Console.WriteLine(Number);
            return comparator(x, y);
        }
    }
}
