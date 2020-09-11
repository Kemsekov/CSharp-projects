using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Abstract_factory.BrandEnums;
namespace TemporaryProj.Abstract_factory
{
    public abstract class SodaFactory
    {
        public static Brands _Brand { get; protected set; }

        public abstract SodaCap CreateCap();
        public abstract SodaBottle CreateBottle();
        public abstract SodaWater CreateWater();
    }


}
