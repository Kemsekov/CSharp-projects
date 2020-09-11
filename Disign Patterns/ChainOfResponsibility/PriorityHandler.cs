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
                    return;
                }
            }
            Optimize();
        }
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