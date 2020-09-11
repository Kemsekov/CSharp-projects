using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyNamespace.CheckerEvents
{

    public enum States
    {
        IsWorking,
        Free
    }

    /// <summary>
    /// This class allow you to add many System.Action in one event, that will invoke every sleepInterval milliseconds in async mode
    /// </summary>
    public class StaticChecker
    {

        volatile States state = States.Free;
        public States State { get=>state;}

        /// <summary>
        /// Ditermines how fast in milliseconds event Checker will invoke
        /// </summary>
        public int sleepInterval;
        public int SleepInterval { get=>sleepInterval; 
            set
            {
                if (value >= 0)
                    sleepInterval = value;
                else
                    sleepInterval = 100;
            } }
        object locker = new object();


        event Action check;

        /// <summary>
        /// In this event you can add any System.Action.
        /// </summary>
        public event Action Checker
        {

            add
            {
                check += value;
            }
            remove
            {
                check -= value;
            }

        }

        public StaticChecker(int sleepInterval)
        {
            this.sleepInterval = sleepInterval;
        }


        /// <summary>
        /// This method will start invoking Checker events if State==States.Free every SleepInterval milliseconds
        /// </summary>
        public void Start()
        {
            if (state == States.Free)
            {
                ThreadPool.QueueUserWorkItem( async (object a) =>
                {
                    state = States.IsWorking;
                    while (state == States.IsWorking)
                    {
                        check();
                        await Task.Delay(sleepInterval);
                    }
                });
            }
        }
        /// <summary>
        /// Change State to States.Free and stop Start() method if it is working
        /// </summary>
        public void Stop()
        {
            state = States.Free;
        }

    }
    
}
