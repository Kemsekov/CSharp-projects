using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Builder.Abstract_House_Builder;

namespace TemporaryProj.Builder.Concrete_House_Builder
{
    class Basement : AbstractBasement
    {

        public Basement(int height)
        {
            this.height = height;
        }
        protected int height { get; set; }

        public override int GetHeight()
        {
            return height;
        }
    }
}
