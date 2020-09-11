using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Builder.Abstract_House_Builder;
using TemporaryProj.Builder.Concrete_House_Builder;

namespace TemporaryProj.Builder
{
    abstract class AbstractHouseBuilder
    {
        public abstract House GetResult();
        public abstract void BuildRoof(int height);
        public abstract void BuildFloor(int height);
        public abstract void BuildBasement(int height);

    }
}
