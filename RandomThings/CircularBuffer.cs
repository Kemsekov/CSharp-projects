using System;
using System.Collections.Generic;

namespace CSharp_projects.RandomThings
{
    public class CircularBuffer<T>
    {
        public static void RunMe(){
            CircularBuffer<int> buf = new CircularBuffer<int>(5);
            System.Console.WriteLine("Print a num");
            string str="";

            while(true)
            try{
                str = Console.ReadLine();
                var num = int.Parse(str);
                buf.Add(num);
                System.Console.WriteLine("What we got:\n");
                foreach(var a in buf){
                    System.Console.WriteLine(a);
                }
                System.Console.WriteLine("\nPrint a num");
            }
            catch (FormatException ex){
                if(str!="Stop")
                System.Console.WriteLine("This is not a num. Print \"Stop\" to end this program.");
                else break;
            }
        }
        public CircularBuffer(int size=3)
        {
            buffer = new LinkedList<T>();
            this.size = size; 
        }
        public void Add(T element){
            buffer.AddLast(element);
            if(buffer.Count>size)
            buffer.RemoveFirst();
        }

        public IEnumerator<T> GetEnumerator(){
            return buffer.GetEnumerator();
        }

        public T this[int n]{
            get{
                n%=size;
                foreach(var a in buffer){
                    if(--n==-1){
                        return a;
                    }
                }
                throw new Exception("Empty buffer");
            }
            set{
                n%=size;
                var enumer = buffer.First;
                while(--n!=-1){
                    enumer = enumer.Next;
                }
                enumer.Value = value;

            }
        }
        readonly int size;
        LinkedList<T> buffer;
    }
}