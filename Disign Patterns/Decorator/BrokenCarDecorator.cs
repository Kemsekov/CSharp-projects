using System;
using System.Collections.Generic;
namespace TemporaryProj.Decorator{
    class BrokenCarDecorator : CarDecorator
    {
        public BrokenCarDecorator(ICar car) : base(car)
        {
            if(car is Car c)
            c.state = CarStates.BROKEN;
        }

        public override void move(int speed)
        {
            System.Console.WriteLine("Car is broken and feel bad... It's speed is decreased!");
            base.move(speed>20 ? speed-20:0);
        }


        public override void turnOff()
        {
            base.turnOff();
        }

        public override void turnOn()
        {
            base.turnOn();
        }
    }
}