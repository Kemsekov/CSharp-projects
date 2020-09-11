using System;
using System.Collections.Generic;
namespace TemporaryProj.Decorator{
abstract class CarDecorator : ICar{
    protected ICar car;
    public CarDecorator(ICar car)
    {
        this.car = car;
    }

        public virtual void move(int speed)
        {
            car.move(speed);
        }

        public virtual void turnOff()
        {
            car.turnOff();
        }

        public virtual void turnOn()
        {
            car.turnOn();
        }
    }
}