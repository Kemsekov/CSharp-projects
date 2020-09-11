using System;
using System.Collections.Generic;
using SortLinkedList;

namespace TemporaryProj
{
        
        class TmpProj
        {

        static void Main(string[] args)
        {
            Random rand = new Random();
            LinkedList<char> list = new LinkedList<char>();

            for(int a = 0; a<10; a++)
            list.AddLast(Convert.ToChar(rand.Next(0,100)));

            var res = DoMergeSort.Sort(list,(char a, char b)=>b-a);

            foreach(var a in res)
            System.Console.WriteLine(Convert.ToInt32(a));
            
        }
    }
}
