using System;
using SortLinkedList;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace TemporaryProj.ChainOfResponsability{
    ///<summary>
    ///In here implemented Chain of responsibility disign pattern but with dynamic changing priority list
    ///</summary>
    public class PriorityHandlerChainImpl : HandlerChainImpl{
        IfRequestProcessed notify;
        ///<summary>
        ///Define how often list of Handlers will sort by using Optimize() method
        ///</summary>
        public int FrequencyOfOptimize {get; protected set;}
        int countOfCallingProcessMethod = 0;

        public PriorityHandlerChainImpl(LinkedList<Handler> list, int frequencyOfOptimize = 10) : base(list)
        {
            FrequencyOfOptimize = frequencyOfOptimize;
        }
        public PriorityHandlerChainImpl(int frequencyOfOptimize = 10) : base()
        {
            FrequencyOfOptimize = frequencyOfOptimize;
        }
        public override event IfRequestProcessed NotifyIfSuccess{
        add{
            notify+=value;
        }
        remove{
            notify-=value;
        }
        }
        public override void AddHandler(Handler handler){
            lock(list){
            list.AddLast(handler);
            }
        }
        public override bool RemoveHandler(Handler handler){
            lock(list){
            return list.Remove(handler);
            }
        }
        public override void Process(object request){
            ProcessNode(request);
            if(++countOfCallingProcessMethod==FrequencyOfOptimize){
            Optimize();
            countOfCallingProcessMethod = 0;
            }
        }
        public void SetFrequency(int n){
            lock(list){
                FrequencyOfOptimize = n;
            }
        }
        ///<summary>
        ///Optimize the list of handlers by sorting them by the priority
        ///The more often some Handler successfully process the request the more its priority is
        ///</summary>
        protected void Optimize(){

            lock(list)
            {
                var buf = from num in list
                        orderby num.Priority
                        select num;
                list = new LinkedList<Handler>(buf);
            }
        }
        protected void Swap(LinkedListNode<Handler> node1, LinkedListNode<Handler> node2){
            list.AddBefore(node1,new LinkedListNode<Handler>(node2.Value));
            list.Remove(node2);
        }
        protected void ProcessNode(object request){
            Monitor.Enter(list);
            try{
                foreach(var a in list)
                if(a.HandleRequest(request)){ //may occur exception
                    a.Priority++;
                    notify?.Invoke(a);        //may occur exception too
                    break;
                }
                else{
                    a.Priority--;
                }
            
            }
            finally{
                Monitor.Exit(list);
            }
        }    
        
    
    }
}