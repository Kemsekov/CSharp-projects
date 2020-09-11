using System;
using System.Collections.Generic;
using SortLinkedList;

namespace TemporaryProj.ChainOfResponsability{
    class PriorityHandler<T>{
        protected LinkedList<Handler<T>> list;
        public PriorityHandler()
        {
            list = new LinkedList<Handler<T>>();
        }

        public void AddHandler(Handler<T> handler){
            list.AddLast(handler);
        }

        public void Process(T request){
            ProcessNode(request,list.First);
        }
        protected void Optimize(uint priority){
            DoMergeSort.Sort(list,(Handler<T> t1, Handler<T> t2)=>
            t1.Priority-t2.Priority);
        }

        protected void ProcessNode(T request,LinkedListNode<Handler<T>> node){
            if(node!=null){
                if(!node.Value.HandleRequest(request)){
                    node.Value.Priority--;
                    ProcessNode(request,node.Next);
                }
                else{
                    node.Value.Priority++;
                }
            }
        }

    }
}