using System;
using System.Collections.Generic;
using SortLinkedList;
using System.Threading;

namespace TemporaryProj.ChainOfResponsability{
    ///<summary>
    ///In here implemented Chain of responsibility disign pattern but with dynamic changing priority list
    ///</summary>
    class PriorityHandler<T>{
        public delegate void IfRequestProcessed(Handler<T> handler);
        IfRequestProcessed notify;
        
        ///<summary>
        ///Invokes if handler successfully processed request
        ///</summary>
        public event IfRequestProcessed NotifyIfSuccess{
            add{
                notify+=value;
            }
            remove{
                notify-=value;
            }
        }
        public PriorityHandler()
        {
            list = new LinkedList<Handler<T>>();
        }

        public void AddHandler(Handler<T> handler){
            lock(list){
            list.AddLast(handler);
            }
        }

        public bool RemoveHandler(Handler<T> handler){
            lock(list){
            return list.Remove(handler);
            }
        }
        public void Process(T request){
            ProcessNode(request,list.First);
            Optimize();
        }
        ///<summary>
        ///Optimize the list of handlers by sorting them by the priority
        ///The more often some Handler successfully process the request the more its priority is
        ///</summary>
        protected void Optimize(){
            lock(list){
            DoMergeSort.Sort(list,(Handler<T> t1, Handler<T> t2)=>
            t1.Priority-t2.Priority);
            }   
        }
        protected void ProcessNode(T request,LinkedListNode<Handler<T>> node){
            Monitor.Enter(list);
            try{
            if(node!=null){
                if(!node.Value.HandleRequest(request)){ //may occur exception
                    node.Value.Priority--;
                    ProcessNode(request,node.Next);
                }
                else{
                    node.Value.Priority++;
                    notify?.Invoke(node.Value);         //may occur exception too
                }
            }
            }
            finally{
                Monitor.Exit(list);
            }
        
        }
        protected LinkedList<Handler<T>> list;
    }
}