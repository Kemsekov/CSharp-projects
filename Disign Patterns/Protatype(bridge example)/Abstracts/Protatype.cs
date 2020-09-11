using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemporaryProj.POP
{
    public abstract class Prototype : ICloneable<Prototype>
    {
        public static int AmountOfCopies { get; protected set; } = 0;

        protected PrototypeImpl impl { get; set; }
        public Prototype lastCreated { get;protected set; }
        public Prototype(PrototypeImpl implementor)
        {
            impl = implementor;
        }
        public async virtual void SendSharedMethod(Action<PrototypeImpl> action)
        {
            var task = Task.Run(()=> { action(impl); });
            lastCreated?.SendSharedMethod(action);
            await task;
        }
        public abstract Prototype Clone();

    }
}
