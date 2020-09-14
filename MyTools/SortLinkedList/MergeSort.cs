using System.Collections.Generic;
using System;
//In this tool i use CompareAdapter<T>, that allows me to compare types

namespace SortLinkedList{
    class SortType{
        protected static LinkedListNode<T> MergeSort<T>(LinkedListNode<T> list_first,int count,Func<T,T,int> cmp)
        {   
            if(list_first==null || cmp==null)
            throw new NullReferenceException();
            if(count<=1)
            return list_first;
            
            var half = list_first;

            for(int i = count/2;i>0;i--){
                half = half.Next;
            }

            var half1 = MergeSort(list_first,count/2,cmp);
            var half2 = MergeSort(half,count-count/2,cmp);

            return Merge(half1,half2,count/2,count-count/2,cmp);
        } 
        protected static LinkedListNode<T> Merge<T>(LinkedListNode<T> list1_first, LinkedListNode<T> list2_first,int n1,int n2,Func<T,T,int> cmp){
            if(list1_first == null || list2_first== null)
            throw new NullReferenceException();

            LinkedList<T> result = new LinkedList<T>();

            LinkedListNode<T> list1_current = list1_first;
            LinkedListNode<T> list2_current = list2_first;

            while(n1>0 || n2>0){
                if(n1>0 && n2>0){
                    if(cmp(list1_current.Value,list2_current.Value)>0){
                        result.AddLast(list1_current.Value);
                        list1_current = list1_current.Next;
                        n1--;
                        continue;
                    }
                    else{
                        result.AddLast(list2_current.Value);
                        list2_current = list2_current.Next;
                        n2--;
                        continue;
                    }
                }
                if(n1>0){
                    result.AddLast(list1_current.Value);
                    list1_current = list1_current.Next;
                    n1--;
                    continue;
                } 
                if(n2>0){
                    result.AddLast(list2_current.Value);
                    list2_current = list2_current.Next;
                    n2--;
                }
                
            }

            
            return result.First;
        }

        ///<summary>
        ///Process merge sort for list. How it sorting list depending on CompDelegate
        ///</summary> 
        /// <param name="cmp"> should return int as result of comparing 2 objects of one type</param>
        public static LinkedList<T> Sort<T>(LinkedList<T> unsorted,Func<T,T,int> cmp){
            
            return MergeSort(unsorted.First,unsorted.Count,cmp).List;
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