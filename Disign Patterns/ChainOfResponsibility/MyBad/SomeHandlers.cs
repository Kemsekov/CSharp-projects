using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemporaryProj.ChainOfResponsability{
    //This is bad example but i don't mind at all
    class PrintStringHandler : Handler
    {
        public override bool HandleRequest(object request)
        {
            Task.Delay(50);
            if(request is string str){
            System.Console.WriteLine(str);
            return true;
            }
            else 
            return false;
        }
    }
    class PrintIntHandler : Handler
    {
        public override bool HandleRequest(object request)
        {
            Task.Delay(10);
            if(request is int num){
            System.Console.WriteLine(num);
            return true;
            }
            return false;
        }
    }
    class PrintCollection<T> : Handler
    {
        public override bool HandleRequest(object request)
        {
            Task.Delay(10);
            if(request is IEnumerable<T> list){
                foreach(var a in list)
                System.Console.WriteLine(a);
                return true;
            }
            return false;
        }
    }
    

}