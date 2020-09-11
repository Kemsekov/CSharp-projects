using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using TemporaryProj.Abstract_factory;
using TemporaryProj.Abstract_factory.BrandEnums;
using TemporaryProj.Abstract_Soda_factory.CocaCola;

namespace TemporaryProj.Abstract_factory.CocaCola
{

    class CocaColaFactory : SodaFactory
    {
        static CocaColaFactory()
        {
            _Brand = Brands.CocaCola;
        }

        public override SodaBottle CreateBottle()
        {
            return new CocaColaBottle();
        }

        public override SodaCap CreateCap()
        {
            return new CocaColaCap();
        }

        public override SodaWater CreateWater()
        {
            return new CocaColaWater();
        }
    }
}
