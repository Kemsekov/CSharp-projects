using System;
using System.Diagnostics.CodeAnalysis;

namespace TemporaryProj.ChainOfResponsability{
    abstract class Handler<T> : IComparable<Handler<T>>{
        //if request was successfuly processed return true - else false
        public abstract bool HandleRequest(T request);

        public int CompareTo(Handler<T> other)
        {
            return Priority-other.Priority;
        }

        public int Priority{get;set;} = 0;

        public static bool operator<=(Handler<T> t1,Handler<T> t2){
            return t1.Priority<=t2.Priority;
        }
        public static bool operator>=(Handler<T> t1,Handler<T> t2){
            return t1.Priority>=t2.Priority;
        }
    }
}