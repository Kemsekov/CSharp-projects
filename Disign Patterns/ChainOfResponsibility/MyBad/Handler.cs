using System;

namespace TemporaryProj.ChainOfResponsability{
    public abstract class Handler{
        ///<summary>
        ///if request was successfuly processed return true - else false
        ///</summary>
        public abstract bool HandleRequest(object request);
        public int Priority{get;set;} = 0;
    }
}