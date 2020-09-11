using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace TemporaryProj.Singleton
{
    public class Singleton
    {
        protected static Singleton self { get; set; } = null;
        protected static int counter { get; set; } = 0;
        public static int MaxAmountOfObjects { get; set; }
        public object Data { get; set; }
        private Singleton(object data)
        {
            Data = data;
        }
        public static Singleton Instance(object data)
        {
            if (counter++ < MaxAmountOfObjects)
                self = new Singleton(data);
            return self;
        }
    }
}
