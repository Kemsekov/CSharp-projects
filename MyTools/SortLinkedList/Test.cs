using System;
using System.Collections.Generic;
using SortLinkedList;

namespace TemporaryProj.Tests{

    partial class tests{
        public static void MergeSortTest(){
        var list = new LinkedList<int>();
        var rand = new Random();
        int sum = 0;
        int sum1 = 0;
        for(var a = rand.Next(0,100);a>0;a--){
            int buf = rand.Next(0,100);
            sum+=buf;
            list.AddLast(buf);
            }

        for(int p = 0;p<10;p++)
        list = SortType.Sort(list,(int n1, int n2)=>n1-n2);

        foreach(var p in list){
        sum1+=p;
        Console.WriteLine(p);
        }
        System.Console.WriteLine("Control sub is " + (sum-sum1));
        list.Clear();
        }
    }
}