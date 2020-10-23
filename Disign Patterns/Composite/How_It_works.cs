using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Composite
{
    static class How_It_works
    {
        public static void Run()
        {
            var root = new Branch("root");
            var branch1 = new Branch("br1");
            var branch2 = new Branch("br2");
            var branch3 = new Branch("br3");
            var leaf1 = new Data<int>("age", 23);
            var leaf2 = new Data<int>("weight", 66);
            root.AddChild(branch1);
            root.AddChild(branch2);
            branch2.AddChild(branch3);
            branch3.AddChild(new Data<int>("something",5553));
            branch3.AddChild(new Data<string>("SecondName","Egorov"));
            branch1.AddChild(leaf1);
            branch1.AddChild(new Data<int>("height", 44));
            branch2.AddChild(leaf2);
            branch2.AddChild(new Data<string>("name", "Dima"));
            //Мысль в том, что можно обрабатывать разные типы данных в одном дереве по-разному.
            foreach(var c in root){
                if(c is Data<int> data){
                    Console.WriteLine($"{data.name} {data.data}");
                }
                if(c is Data<string> data1){
                    Console.WriteLine($"{data1.name} {data1.data}");
                }
            }
            
        }
    }
}
