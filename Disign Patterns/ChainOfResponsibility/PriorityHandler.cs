using System;
using System.Collections.Generic;
using SortLinkedList;

namespace TemporaryProj.ChainOfResponsability{
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
            list.AddLast(handler);
        }

        public bool RemoveHandler(Handler<T> handler){
            return list.Remove(handler);
        }

        public void Process(T request){
            ProcessNode(request,list.First);
        }
        ///<summary>
        ///Optimize the list of handlers by sorting them by the priority
        ///The more often some Handler successfully process the request the more its priority is
        ///</summary>
        protected void Optimize(){
            DoMergeSort.Sort(list,(Handler<T> t1, Handler<T> t2)=>
            t1.Priority-t2.Priority);
        }

        protected void ProcessNode(T request,LinkedListNode<Handler<T>> node){
            if(node!=null){
                if(!node.Value.HandleRequest(request)){
                    node.Value.Priority--;
                    ProcessNode(request,node.Next);
                    return;
                }
                else{
                    node.Value.Priority++;
                    notify?.Invoke(node.Value);
                    return;
                }
            }
            Optimize();
        }
        protected LinkedList<Handler<T>> list;
    }
}
/*
Example of using

static void Main(string[] args)
        {
            
            Random rand = new Random();
            LinkedList<char> list = new LinkedList<char>();

            for(int a = 0; a<11; a++)
            list.AddLast(Convert.ToChar(rand.Next(0,100)));

            var res = DoMergeSort.Sort(list,(char a, char b)=>b-a);

            foreach(var a in res)
            System.Console.WriteLine(Convert.ToInt32(a));
            
        }
------------------------------------------------
Outputs:
3
5
26
27
27
44
64
64
86
86

*/