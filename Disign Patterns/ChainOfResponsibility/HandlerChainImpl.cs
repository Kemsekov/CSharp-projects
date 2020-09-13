
using System.Collections.Generic;

namespace TemporaryProj.ChainOfResponsability{
    public abstract class HandlerChainImpl<T>{
        public HandlerChainImpl()
        {
            list = new LinkedList<Handler<T>>();
        }
        public abstract void AddHandler(Handler<T> handler);
        public abstract bool RemoveHandler(Handler<T> handler);
        public abstract void Process(T request);
        public delegate void IfRequestProcessed(Handler<T> handler);
        
        ///<summary>
        ///Invokes if handler successfully processed request
        ///</summary>
        public abstract event IfRequestProcessed NotifyIfSuccess;
        protected LinkedList<Handler<T>> list;
    }
}