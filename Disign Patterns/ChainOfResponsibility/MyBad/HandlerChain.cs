using System;
using System.Collections.Generic;
using SortLinkedList;
using System.Threading;

namespace TemporaryProj.ChainOfResponsability{
    
    class HandlerChain : HandlerChainImpl
    {
        protected HandlerChainImpl impl;
        public HandlerChain(HandlerChainImpl impl)
        {
            if(impl==null) 
            throw new NullReferenceException();

            this.impl = impl;
        }

        public override event IfRequestProcessed NotifyIfSuccess
        {
            add=>impl.NotifyIfSuccess += value;
            remove=>impl.NotifyIfSuccess -= value;
        }


        public override void AddHandler(Handler handler)
        {
            impl.AddHandler(handler);
        }


        public override void Process(object request)
        {
            impl.Process(request);
        }


        public override bool RemoveHandler(Handler handler)
        {
            return impl.RemoveHandler(handler);
        }
    }
}