using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemporaryProj.Command{
    class Command{
        public Music music{get;protected set;}
        public int Timer{get;protected set;} = 0;
        public States state{get;protected set;} = States.Waiting;
        public Command(Music music)
        {
            this.music = music;
        }
        public void Play(){
            if(state!=States.Playing){
                state = States.Playing;
                System.Console.WriteLine("Now playing from - ",music.Source);
                while(Timer++<music.Time && state==States.Playing){
                    System.Console.WriteLine("...");
                }
            }
            if(Timer==music.Time)
            state = States.Ended;
        }
        public void Stop(){
            state = States.Stopped;
        }
        public void Pause(){
            state = States.Paused;
        }
        public void Restart(){
            if(state!=States.Playing){
                state = States.Restarting;
                Timer = 0;
                Play();
            }
        }
    }
}