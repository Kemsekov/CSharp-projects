using System;
using System.Diagnostics.CodeAnalysis;

namespace TemporaryProj.ChainOfResponsability{
    abstract class Handler<T>{
        //if request was successfuly processed return true - else false
        public abstract bool HandleRequest(T request);
        public int Priority{get;set;} = 0;
    }
}