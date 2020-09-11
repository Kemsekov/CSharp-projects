using System;
using System.Collections.Generic;

namespace TemporaryProj.Observer{
    public class SomeClass<T> : IObservable<T>
    {
        List<IObserver<T>> subs;
        public SomeClass()
        {
            subs = new List<IObserver<T>>();
        }
        public IDisposable Subscribe(IObserver<T> observer){
            subs.Add(observer);
            return new Unsubscriber<T>(observer,subs);
        }
        public bool Remove(IObserver<T> observer){
            if(subs.Contains(observer)){
            subs.Remove(observer);
            return true;
            }
            return false;
        }
    }
}