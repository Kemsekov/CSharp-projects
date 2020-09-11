using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Builder.Concrete_House_Builder
{
    class Foreman
    {
        public AbstractHouseBuilder Builder { get; protected set; }
        public House house { get; protected set; }
        public Foreman(AbstractHouseBuilder builder)
        {
            Builder = builder;
            house = Builder.GetResult();
        }
        public void BuildTwoStoreyHouse(int basemantHeight, int floorHeight, int roofHeight)
        {
            Builder.BuildBasement(basemantHeight);
            Builder.BuildFloor(floorHeight);
            Builder.BuildFloor(floorHeight);
            Builder.BuildRoof(roofHeight);
        }
        public void BuildOneStoreyHouse(int basemantHeight, int floorHeight, int roofHeight)
        {
            Builder.BuildBasement(basemantHeight);
            Builder.BuildFloor(floorHeight);
            Builder.BuildRoof(roofHeight);
        }
    }
}
