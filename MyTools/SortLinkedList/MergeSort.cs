using System.Collections.Generic;
using System;
//In this tool i use CompareAdapter<T>, that allows me to compare types

namespace SortLinkedList{
    class DoMergeSort{
    protected static (LinkedListNode<T>,int) MergeSort<T>(LinkedListNode<T> left_node,int Count,Func<T,T,int> cmp){

                if(Count<=1)
                return (left_node,Count);

                int left_size = Count/2;
                int right_size = Count-left_size;

                LinkedListNode<T> right_node = left_node;

                for(int co = right_size;co>1;co--){
                    right_node = right_node.Next;
                }
                
                var a = MergeSort(left_node,left_size,cmp);
                var b = MergeSort(right_node,right_size,cmp);
                
                left_node = a.Item1;
                left_size = a.Item2;
                right_node = b.Item1;
                right_size = b.Item2;

                return Merge(left_node,left_size,right_node,right_size,cmp);
            } 
           protected static (LinkedListNode<T>,int) Merge<T>(LinkedListNode<T> left_node,
                                         int left_size, 
                                         LinkedListNode<T> right_node, 
                                         int right_size,Func<T,T,int> cmp)
            {
                LinkedList<T> result = new LinkedList<T>();
                
                if(left_node!=null && right_node!=null & left_size>0 && right_size>0){
                    while(left_size>0 || right_size>0){
                        if(left_size>0 && right_size>0){
                            if(cmp(left_node.Value,right_node.Value)>0){
                                result.AddLast((left_node));
                                left_size--;
                                left_node = left_node.Next;
                            }
                            else{
                                result.AddLast(right_node);
                                right_size--;
                                right_node = right_node.Next;
                            }
                            continue;
                        }
                        if(left_size>0){
                            result.AddLast(left_node);
                            left_size--;
                            left_node=left_node.Next;
                            continue;
                        }
                        if(right_size>0){
                            result.AddLast(right_node);
                            right_size--;
                            right_node = right_node.Next;
                            continue;
                        }
                    }
                }
                return (result.First,result.Count);
            }
            
        ///<summary>
        ///Process merge sort for list. How it sorting list depending on CompDelegate
        ///</summary> 
        /// <param name="cmp"> should return int as result of comparing 2 objects of one type</param>
        public static LinkedList<T> Sort<T>(LinkedList<T> unsorted,Func<T,T,int> cmp){
            
            return MergeSort(unsorted.First,unsorted.Count,cmp).Item1.List;
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