using System;
using System.Collections.Generic;

namespace TemporaryProj.Command{
    class Player{
        LinkedList<Command> playList;
        LinkedListNode<Command> current = null;
        int ID = 0;
        public Player()
        {
            playList = new LinkedList<Command>();
        }
        public void AddInQueue(Music music){
            ID++;
            playList.AddLast(new Command(music));
            if(current==null)
            current = playList.Last;
        }
        public void Remove(int id){
            if (id <= 0 || id > ID)
            {
                System.Console.WriteLine("There is no such ID.");
            }
            else
            {
                var en = playList.First;
                while (id-- > 0)
                    en = en.Next;

                if(current == en)
                    Stop();

                playList.Remove(en);
                ID--;
                
            }
        }
        public void Start(){
            while(true)
                if (current == null)
                {
                    System.Console.WriteLine("There is no music in queue.");
                }
                else
                {
                    current.Value.Play();

                    //if playList is end
                    if (current == playList.Last)
                        break;

                    //if a whole song was played
                    if (current.Value.state == States.Ended)
                        current = current.Next;
                }
        }
        public void Stop(){
            if(current!=null)
            current.Value.Stop();
        }
        public void Pause(){
            if(current!=null)
            current.Value.Pause();
        }
        public void Restart(){
            if(current!=null)
            current.Value.Restart();
        }
    }
}