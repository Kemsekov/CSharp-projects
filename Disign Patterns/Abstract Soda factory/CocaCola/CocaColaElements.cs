using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Abstract_factory;

namespace TemporaryProj.Abstract_Soda_factory.CocaCola
{
    public class CocaColaCap : SodaCap
    {

    }
    public class CocaColaBottle : SodaBottle
    {
        public override void FillBottle(SodaWater water)
        {
            throw new NotImplementedException();
        }
    }
    public class CocaColaWater : SodaWater
    {

    }
}
