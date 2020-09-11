using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Abstract_factory.BrandEnums;

namespace TemporaryProj.Abstract_factory
{
    
    public abstract class SodaCap 
    {
        

    }

    public abstract class SodaBottle 
    {
        uint waterAmount=0;
        uint maxAmountWater = 100;
        uint minAmountWater = 0;
        public uint WaterAmount
        {
            get => waterAmount;
            protected set
            {
                if (value > maxAmountWater)
                    waterAmount= maxAmountWater;
                else
                    waterAmount = value;
            }
        }
        public abstract void FillBottle(SodaWater water);
    
    }

    public abstract class SodaWater 
    {
        uint waterAmount;
        public uint WaterAmount { get; protected set; }
    }

    
}
