using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Factory_method
{
    class ConcreteFactoryMethod : FactoryMethod
    {
        public override Product CreateProduct()
        {
            return new ConcreteProduct();
        }
    }
}
