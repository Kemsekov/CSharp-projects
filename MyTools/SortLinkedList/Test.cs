using System;
using System.Collections.Generic;
using SortLinkedList;
using System.Diagnostics;
using System.Linq;

namespace TemporaryProj.Tests{

    partial class tests{
        public static void MergeSortTest(){
        
        Stopwatch watch = new Stopwatch();
        
        var list = new LinkedList<int>();
        var rand = new Random();

        //values for control sub(sum of list's elements before and after sort)
        int sum = 0;
        int sum1 = 0;
        
        //size of list and max value in list
        int size = 10000;
        int max = 1000;

        //If sorted list will be not sorted correctly this varable will have a value of wrong index
        int errorIndex = -1;

        //filling list with random values
        for(var a = size;a>0;a--){
            int buf = rand.Next(0,max);
            sum+=buf;
            list.AddLast(buf);
            }
        
        //Do sort and capture time spent on it

        watch.Start();

        list = SortType.Sort(list,(int n1, int n2)=>n1-n2);
        
        watch.Stop();
        
        //Make control sub and check if sort was error
        int Value = max;
        int index = 0;
        foreach(var p in list){
        sum1+=p;
        index++;
        Console.WriteLine(p);
        if(p<=Value){       //if sorted well, then every next value should be less or equal to previous
            Value = p;
        }
        else{
            if(errorIndex==-1)
            errorIndex = index;
        }
        }

        //Conclusion of sort        

        Console.WriteLine("Control sub :\t\t" + (sum-sum1));
        Console.WriteLine("Time :\t\t\t"+watch.ElapsedMilliseconds);
        Console.WriteLine("Size of list :\t\t"+size);
        Console.WriteLine("Range of values :\t"+$"{0} {max}");

        
        if(errorIndex!=-1){
            System.Console.WriteLine("First error index: "+errorIndex);
        }
        }
        public static void LINQSortTest(){
Stopwatch watch = new Stopwatch();
        
        var list = new LinkedList<int>();
        var rand = new Random();

        //values for control sub(sum of list's elements before and after sort)
        int sum = 0;
        int sum1 = 0;
        
        //size of list and max value in list
        int size = 10000;
        int max = 1000;

        //If sorted list will be not sorted correctly this varable will have a value of wrong index
        int errorIndex = -1;

        //filling list with random values
        for(var a = size;a>0;a--){
            int buf = rand.Next(0,max);
            sum+=buf;
            list.AddLast(buf);
            }
        
        //Do sort and capture time spent on it

        watch.Start();

        var res = from num in list
                    orderby num
                    select num;
        list = new LinkedList<int>(res);
        watch.Stop();
        
        //Make control sub and check if sort was error
        int Value = max;
        int index = 0;
        foreach(var p in list){
        sum1+=p;
        index++;
        Console.WriteLine(p);
        if(p<=Value){       //if sorted well, then every next value should be less or equal to previous
            Value = p;
        }
        else{
            if(errorIndex==-1)
            errorIndex = index;
        }
        }

        //Conclusion of sort        

        Console.WriteLine("Control sub :\t\t" + (sum-sum1));
        Console.WriteLine("Time :\t\t\t"+watch.ElapsedMilliseconds);
        Console.WriteLine("Size of list :\t\t"+size);
        Console.WriteLine("Range of values :\t"+$"{0} {max}");

        
        if(errorIndex!=-1){
            System.Console.WriteLine("First error index: "+errorIndex);
        } 
        }
    }
}