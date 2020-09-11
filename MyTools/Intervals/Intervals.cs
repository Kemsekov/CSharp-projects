using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj
{
    class Intervals<T> : Dictionary<int, T>
    {
        SortedSet<int> keys = new SortedSet<int>();
        public new void Add(int key, T value)
        {
            if (keys.Add(key))
                base.Add(key, value);
        }
        new public T this[int key]
        {
            get
            {
                foreach (var a in keys.Reverse())
                {

                    if (key >= a)
                    {
                        key = a;
                        break;
                    }
                }
                return base[key];
            }
            set
            {
                foreach (var a in keys)
                    if (a == key)
                    {
                        base[key] = value;
                        return;
                    }
                this.Add(key, value);
            }
        }
    }
}
