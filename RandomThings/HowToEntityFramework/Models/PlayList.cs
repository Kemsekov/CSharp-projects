using System;
using System.Collections;


namespace CSharp_projects.RandomThings
{
    public class PlayList
    {
        public PlayList(string TrackName){
            Track = TrackName;
        }
        public PlayList(){}
        public int ID{get;set;}
        public string Track{get;set;}
    }
}