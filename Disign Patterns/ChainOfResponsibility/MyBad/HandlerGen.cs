using System;

namespace TemporaryProj.ChainOfResponsability{
    public class Handler<T> : Handler
    {
        public override bool HandleRequest(object request)
        {
            if(request is T req)
            return handl(req);
            else 
            return false;
        }
        public Handler(Func<T,bool> handler)
        {
            handl = handler;
        }
        Func<T,bool> handl;
    }
}