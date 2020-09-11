using System;

namespace TemporaryProj.Strategy
{
    class Container{
        IMethod method;
        public void Switch(IMethod method) => this.method = method;
        public void Make(){
            System.Console.WriteLine("WE are");
            method.DoSomething();
        }
    }
}