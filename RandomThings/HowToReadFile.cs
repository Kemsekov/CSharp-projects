using System.IO;
using System.Text;

namespace CSharp_projects.RandomThings
{
    public class HowToReadFile
    {
        public static void ReadFileExample(){
            //create a stream
            var fl = File.Open("results.txt",FileMode.Open);

            //create a buffer whose size is equal to stream size
            byte[] buf = new byte[fl.Length];

            //read whole file into buffer
            fl.Read(buf,0,(int)fl.Length);

            //encode a buffer into UTF8 string
            var res = Encoding.UTF8.GetString(buf,0,buf.Length); 

            System.Console.WriteLine(res);
        }
    }
}