using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Protatype
{
    /// <summary>
    /// Happen when client try to add a second shared method to single TemporaryProj.POP.PrototypeImpl object
    /// </summary>
    class SharedMethodException : Exception
    {
        public override string Message => "For TemporaryProj.POP.PrototypeImp type allowed only single shared method for single object.";
    }
}
