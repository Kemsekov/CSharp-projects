using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Builder.Abstract_House_Builder;

namespace TemporaryProj.Builder.Concrete_House_Builder
{
    class HouseBuilder : AbstractHouseBuilder
    {
        private House house { get; set; }
        public HouseBuilder()
        {
            house = new House();
        }
        public override void BuildBasement(int height)
        {
            house.basements.Add(new Basement(height));
        }

        public override void BuildFloor(int height)
        {
            house.floors.Add(new Floor(height));
        }

        public override void BuildRoof(int height)
        {
            house.roof = new Roof(height);
        }

        public override House GetResult()
        {
            return house;
        }
    }
}
