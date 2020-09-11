using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Abstract_factory.BrandEnums;

namespace TemporaryProj.Abstract_factory.Soda
{
    public class Soda
    {
        private Soda()
        {

        }

        public Soda(SodaFactory factory)
        {
            Cap = factory.CreateCap();
            Water = factory.CreateWater();
            Bottle = factory.CreateBottle();
        }
        public readonly Brands _Brand;
        public SodaCap Cap { get; protected set; }
        public SodaWater Water { get; protected set; }
        public SodaBottle Bottle { get; protected set; }

        protected void AssembleSoda()
        {

        }

    }
}
