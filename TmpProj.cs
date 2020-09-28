using System;
using System.Collections.Generic;
using SortLinkedList;
using TemporaryProj.ChainOfResponsability;
using System.Linq;
using TemporaryProj.Tests;
using ManagedBass;
using System.IO;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
namespace TemporaryProj
{
        
        class TmpProj
        {
        static void Main(string[] args)
        {//(?<=\\[Source\\])\n.*?(?=\\[|$)
            var source = new Regex("(?<=\\[Source\\])\n.*?(?=\\[|$)",RegexOptions.Singleline);
            var name = new Regex("(?<=\\[Name\\])\n.*?(?=\\[|$)",RegexOptions.Singleline);
            
            var fl = File.Open("results.txt",FileMode.Open);
            byte[] buf = new byte[fl.Length];
            fl.Read(buf,0,(int)fl.Length);
            var res = Encoding.UTF8.GetString(buf,0,buf.Length);

            var buff = source.Match(res).Value.Trim('\n');

            Console.WriteLine(buff);
            System.Console.WriteLine();

            buff = name.Match(res).Value.Trim('\n');

            Console.WriteLine(buff);
        }
    }
}
