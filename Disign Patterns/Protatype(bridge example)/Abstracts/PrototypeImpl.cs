using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using TemporaryProj.Protatype;

namespace TemporaryProj.POP
{

        public abstract class PrototypeImpl : ICloneable<PrototypeImpl>
        {

            public delegate object Method(params object[] param);
            public Dictionary<string, object> PublicFields { get; protected set; }
            public Dictionary<string, MethodWrapper> PublicMethods { get; set; }

            public Dictionary<string, object> PrivateFields { get; set; }
            public Dictionary<string, object> ProtectedFields { get; set; }

            public Dictionary<string, MethodWrapper> PrivateMethods { get; set; }
            public Dictionary<string, MethodWrapper> ProtectedMethods { get; set; }
        public PrototypeImpl LastCreated { get; protected set; }
        public virtual void AddMethod(string name, Method method)
        {
            PublicMethods.Add(name, new MethodWrapper(this,method,Modifier.Public));
            
        }
        public virtual void AddPrivateMethod(string name, Method method)
        {
            PrivateMethods.Add(name, new MethodWrapper(this, method, Modifier.Private));
        }
        public virtual void AddProtectedMethod(string name, Method method)
        {
            ProtectedMethods.Add(name, new MethodWrapper(this, method, Modifier.Protected));
        }
        public PrototypeImpl()
        {
            PublicFields = new Dictionary<string, object>();
            PublicMethods = new Dictionary<string, MethodWrapper>();
            ProtectedFields = new Dictionary<string, object>();
            ProtectedMethods = new Dictionary<string, MethodWrapper>();
            PrivateFields = new Dictionary<string, object>();
            PrivateMethods = new Dictionary<string, MethodWrapper>();
        }
        public abstract PrototypeImpl Clone();
    }
    

}
