using System;

namespace TemporaryProj.Observer{
    class Observer<T> : IObserver<T>
    {
        IDisposable unsubscriber;
        public void Subscribe(IObservable<T> observer){
            if(observer!=null)
            unsubscriber = observer.Subscribe(this);
        }
        public void OnCompleted()
        {
            System.Console.WriteLine("complete");
            unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("error.");
        }

        public void OnNext(T value)
        {
            System.Console.WriteLine("idk");
        }
        public void Unsubscire(){
            unsubscriber.Dispose();
        }
    }
}