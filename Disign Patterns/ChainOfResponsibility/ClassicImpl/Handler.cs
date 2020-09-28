using System;
using System.Threading;
using System.Collections.Generic;

namespace TemporaryProj.ChainOfResponsability_{
    public abstract class Handler{
        public Handler(Handler next)
        {
            this.next = next;
        }
        Handler next;
        public abstract bool HandleRequest(object request);
    }
}