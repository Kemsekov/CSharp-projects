using System;
using System.Collections.Generic;
using SortLinkedList;
using TemporaryProj.ChainOfResponsability;
using System.Linq;
using TemporaryProj.Tests;
using ManagedBass;
using System.IO;
using System.Threading;
namespace TemporaryProj
{
        
        class TmpProj
        {

        static void Main(string[] args)
        {
            Bass.Init();
            int handle = Bass.CreateStream("Assets/Music/Goose.mp3");
            if(!Bass.ChannelPlay(handle))
            System.Console.WriteLine(Bass.LastError);

            Thread.Sleep(100);
            while(Bass.ChannelIsActive(handle)!=PlaybackState.Stopped)
            Thread.Sleep(100);

            Bass.ChannelStop(handle);
            Bass.MusicFree(handle);
            Bass.Free();
        }
    }
}
