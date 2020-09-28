using System.Text.RegularExpressions;
using System;

namespace CSharp_projects.RandomThings
{
    public class RegexExmaple
    {
        public static void Exmaple(string res){

            /*
            everything that below [Source] and before another [Something] expression will capture in Match.
            */
            var source = new Regex("(?<=\\[Source\\])\n.*?(?=\\[|$)",RegexOptions.Singleline);
            var name = new Regex("(?<=\\[Name\\])\n.*?(?=\\[|$)",RegexOptions.Singleline);
            

            var buff = source.Match(res).Value.Trim('\n');

            Console.WriteLine(buff);
            System.Console.WriteLine();

            buff = name.Match(res).Value.Trim('\n');

            Console.WriteLine(buff);
        }
    }
}

/*
input example :

[Source]
The Some site link
hggjh

[Name]
Name of track
112

output then :

The Some site link
hggjh

Name of track
112

*/