using System;
using System.Threading.Tasks;
namespace TemporaryProj.Decorator{
public class Car : ICar
{
    public CarStates state = CarStates.NORMAL;
    public bool OnMove{get;protected set;}=false;
    public bool EngineOn{get;protected set;} = false;
    public int CurrentSpeed{get;protected set;} = 0;
    public void move(int speed)
    {
        if(EngineOn){
            CurrentSpeed = speed;
            System.Console.WriteLine("Car is go brrr!");
        }
        else{
            System.Console.WriteLine("You MUST turn on car before move!");
        }
    }

    public void turnOff()
    {
        move(0);
        EngineOn = false;
    }

    public void turnOn()
    {
        EngineOn = true;
    }
}
}