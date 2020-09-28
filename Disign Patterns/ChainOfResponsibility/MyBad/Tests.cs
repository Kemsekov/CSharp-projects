using System;
using System.Collections.Generic;
using System.Linq;
using TemporaryProj.ChainOfResponsability;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Text;
/*
quick conclusion:

priority chain is slower than classic when there is only a few handlers, but when 
a number of handlers grow we can see that chain with priority become absolute winner vs 
classic chain.

*/

namespace TemporaryProj.Tests{
    public static partial class tests{
        public static void ChainOfResponsabilityTest(){

            //some varables to test
            var _enum = Enumerable.Range(10,50);
            var str = "HELLO !";
            var num = 30002;

            LinkedList<string> list = new LinkedList<string>();
            for(int i = 0;i<15;i++){
            list.AddLast("First");
            list.AddLast("Second");
            list.AddLast("Third");
            list.AddLast("This is another line!");
            }

            var pairList = new LinkedList<(int,string)>();
            for(int i = 0;i<15;i++){
            pairList.AddLast((2344,"Very good"));
            pairList.AddLast((500,"another one"));
            pairList.AddLast((80011,"and another one"));
            pairList.AddLast((228337,"We need to test it!"));
            pairList.AddLast((59696,"I just adding another type"));
            pairList.AddLast((39458,"yeah"));
            }

            var anotherPairList = new LinkedList<(string,int,string)>();
            for(int i = 0; i<15;i++){
                anotherPairList.AddLast(("We are a",4441,"yup"));
                anotherPairList.AddLast(("HEY",21082,"How are you?"));
                anotherPairList.AddLast(("look at me!",487574,"stop"));
                anotherPairList.AddLast(("Idk what",44239787,"I am doing"));
            }

            var _list = new LinkedList<(string,string,string)>();
            for(int i = 0; i<12;i++){
                _list.AddLast(("T am tired","So much","Help me"));
                _list.AddLast(("This is not okey","fgg","go ahead!"));
                _list.AddLast(("lalaldlld","fffg","Hah"));
            }

            //Chain of handlers that prints values
            LinkedList<Handler> printChain = new LinkedList<Handler>();
            for(int k = 0; k<200;k++)
            printChain.AddLast(new PrintStringHandler());
            printChain.AddLast(new PrintCollection<(string,int,string)>());
            printChain.AddLast(new PrintCollection<string>());
            printChain.AddLast(new PrintCollection<int>());
            printChain.AddLast(new PrintCollection<(string,string,string)>());
            printChain.AddLast(new PrintIntHandler());

            //try to add this line and look at comparasion between priority chain and classic, then remove it
            //and look again
            printChain.AddLast(new PrintCollection<(int,string)>());

            //HandlerChain chain = new HandlerChain(new PriorityHandlerChainImpl(printChain));
            //HandlerChain priorityChain = new HandlerChain(new ClassicHandlerChainImpl(printChain));
            
            HandlerChain chain = new HandlerChain(new ClassicHandlerChainImpl(printChain));
            HandlerChain priorityChain = new HandlerChain(new PriorityHandlerChainImpl(printChain));   

            chain.Process(12);
            Stopwatch classic = new Stopwatch();
            Stopwatch priority = new Stopwatch();

            var priorityTask = Task.Run(()=>{
            priority.Start();

            for(int a = 0;a<500;a++){
                if(a%15>4)
                priorityChain.Process(_enum);
                
                if(a%10==7)
                priorityChain.Process(list);
                if(a%2==0){
                    priorityChain.Process(str);
                    priorityChain.Process(num);
                }
                if(a%5==3){
                    priorityChain.Process(pairList);
                }
                if(a%100<30){
                    priorityChain.Process(anotherPairList);
                }
            }
            priority.Stop();
            });

            var classicTask = Task.Run(()=>{
            classic.Start();
            for(int a = 0;a<500;a++){
                if(a%15>4)
                chain.Process(_enum);
                if(a%10==7)
                chain.Process(list);
                if(a%2==0){
                    chain.Process(str);
                    chain.Process(num);
                }
                if(a%5==3){
                    chain.Process(pairList);
                }
                if(a%100<30){
                    chain.Process(anotherPairList);
                }
            }
            classic.Stop();
            });
            classicTask.Wait();
            priorityTask.Wait();

            FileStream results = File.Open("results.txt",FileMode.Append);

            results.Write(Encoding.UTF8.GetBytes(string.Format(priority.ElapsedMilliseconds + " priority : ")));
            results.Write(Encoding.UTF8.GetBytes(string.Format(classic.ElapsedMilliseconds + " classic\n")));
            results.Close();

            System.Console.WriteLine(priority.ElapsedMilliseconds + " priority");
            System.Console.WriteLine(classic.ElapsedMilliseconds + " classic");
        }
    }
}
