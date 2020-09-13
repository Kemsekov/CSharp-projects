using System;
using System.Threading;

namespace TemporaryProj.ChainOfResponsability{
    public class ClassicHandlerChainImpl<T> : HandlerChainImpl<T>
    {
        public ClassicHandlerChainImpl() : base()
        {
            
        }
        IfRequestProcessed notify;
        public override event IfRequestProcessed NotifyIfSuccess{
            add => notify+=value;
            remove => notify-=value;
        }

        public override void AddHandler(Handler<T> handler)
        {
            lock(list){
                list.AddLast(handler);
            }
        }

        public override void Process(T request)
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

        public override bool RemoveHandler(Handler<T> handler)
        {
            lock(list){
                return list.Remove(handler);
            }
        }
    }
}