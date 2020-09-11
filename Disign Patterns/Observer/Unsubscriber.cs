using System;
using System.Collections.Generic;

namespace TemporaryProj.Observer{
    public class Unsubscriber<T> : IDisposable{
        List<IObserver<T>> subs;
        IObserver<T> observer;
        bool isDisposed = false;
        public Unsubscriber(IObserver<T> observer, List<IObserver<T>> subs)
        {
            this.observer = observer;
            this.subs = subs;
        }

        public void Dispose(){
            if(!isDisposed){
                if(observer!=null && subs.Contains(observer)){
            subs.Remove(observer);
            isDisposed = true;
            }
            }
        }
    }
}