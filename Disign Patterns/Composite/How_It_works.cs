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
            var leaf1 = new Data<int>("age", 23);
            var leaf2 = new Data<int>("weight", 66);
            root.AddChild(branch1);
            root.AddChild(branch2);
            branch1.AddChild(leaf1);
            branch1.AddChild(new Data<int>("height", 44));
            branch2.AddChild(leaf2);
            branch2.AddChild(new Data<string>("name", "Dima"));
            //Мысль в том, что можно обрабатывать разные типы данных в одном дереве по-разному.
            root.Operation((Component data) =>
            {
                if (data is Data<int> integer)
                    Console.WriteLine($"{integer.name} {integer.data}");
                if (data is Data<string> str)
                    Console.WriteLine($"This is string man.. {str.data}");
            });
        }
    }
}
