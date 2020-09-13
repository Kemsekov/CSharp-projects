using System;
using System.Collections.Generic;
using SortLinkedList;
using System.Threading;

namespace TemporaryProj.ChainOfResponsability{
    class HandlerChain<T>
    {
        protected HandlerChainImpl<T> impl;
        public HandlerChain(HandlerChainImpl<T> impl)
        {
            if(impl==null) throw new NullReferenceException();
            this.impl = impl;
        }
        
    }
}