using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Builder.Concrete_House_Builder;

namespace TemporaryProj.Builder.Abstract_House_Builder
{
    abstract class AbstractBasement : IHaveHeight
    {
        public abstract int GetHeight();
    }
}
