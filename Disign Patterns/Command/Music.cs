using System;

namespace TemporaryProj.Command{
    class Music{
        public string Source{get;protected set;}
        public int Time{get;protected set;}
        public Music(string source,int time)
        {
            Time = time;
            Source = source;
        }
    }   
}