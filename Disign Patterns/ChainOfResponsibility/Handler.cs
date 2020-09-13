using System;
using System.Diagnostics.CodeAnalysis;

namespace TemporaryProj.ChainOfResponsability{
    public abstract class Handler<T>{
        ///<summary>
        ///if request was successfuly processed return true - else false
        ///</summary>
        public abstract bool HandleRequest(T request);
        public int Priority{get;set;} = 0;
    }
}