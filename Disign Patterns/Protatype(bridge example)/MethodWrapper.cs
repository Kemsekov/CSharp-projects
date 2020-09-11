using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TemporaryProj.POP
{
    public class MethodWrapper
    {
        public MethodWrapper(PrototypeImpl accessor, PrototypeImpl.Method method, Modifier modifier)
        {
            this.accessor = accessor;
            this.method = method;
            this.modifier = modifier;
            Method = Invoke;
        }
        /// <summary>
        /// Creates public method
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="method"></param>
        public MethodWrapper(PrototypeImpl accessor, PrototypeImpl.Method method)
        {
            this.accessor = accessor;
            this.method = method;
            this.modifier = Modifier.Public;
            Method = Invoke;
        }
        public object Invoke(params object[] prms)
        {
            return method?.Invoke(accessor,prms);
        }
        PrototypeImpl accessor;
        public PrototypeImpl.Method Method { get; protected set; }
        PrototypeImpl.Method method;
        public Modifier modifier;
        public static implicit operator PrototypeImpl.Method(MethodWrapper wrapper) => wrapper.Method;
    }
}
