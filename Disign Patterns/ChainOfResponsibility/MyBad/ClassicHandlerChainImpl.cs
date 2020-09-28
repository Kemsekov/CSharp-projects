using System;
using System.Threading;
using System.Collections.Generic;

namespace TemporaryProj.ChainOfResponsability{
    public class ClassicHandlerChainImpl : HandlerChainImpl
    {
        public ClassicHandlerChainImpl(LinkedList<Handler> list) : base(list)
        {
            
        }
        public ClassicHandlerChainImpl() : base()
        {
            
        }
        IfRequestProcessed notify;
        public override event IfRequestProcessed NotifyIfSuccess{
            add => notify+=value;
            remove => notify-=value;
        }

        public override void AddHandler(Handler handler)
        {
            lock(list){
                list.AddLast(handler);
            }
        }

        public override void Process(object request)
        {
            Monitor.Enter(list);
            try{
            foreach(var a in list){
                if(a.HandleRequest(request)){ //may occur exception
                    notify?.Invoke(a);        //may occur exception
                    break;
                }
            }
            }
            finally{
                Monitor.Exit(list);
            }
        }

        public override bool RemoveHandler(Handler handler)
        {
            lock(list){
                return list.Remove(handler);
            }
        }
    }
}