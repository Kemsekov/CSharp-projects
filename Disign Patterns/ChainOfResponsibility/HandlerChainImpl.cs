
using System.Collections.Generic;

namespace TemporaryProj.ChainOfResponsability{
    public abstract class HandlerChainImpl{
        public HandlerChainImpl(LinkedList<Handler> list){
            var arr = new Handler[list.Count];
            list.CopyTo(arr,0);
            this.list = new LinkedList<Handler>(arr);
        }
        public HandlerChainImpl()
        {
            list = new LinkedList<Handler>();
        }
        public abstract void AddHandler(Handler handler);
        public abstract bool RemoveHandler(Handler handler);
        public abstract void Process(object request);
        public delegate void IfRequestProcessed(Handler handler);
        
        ///<summary>
        ///Invokes if handler successfully processed request
        ///</summary>
        public abstract event IfRequestProcessed NotifyIfSuccess;
        protected LinkedList<Handler> list;
    }
}