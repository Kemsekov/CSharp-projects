using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Abstract_factory.Soda
{
    class DifferentBrandsException : Exception
    {
        public override string Message => "You cannot assemble soda from elements with different brands.";
    }
}
