using System;

namespace TemporaryProj.Flyweight{
    /*
    не вдавайся в подробности, я просто написал что-нибуть типо под тяжёлый объект
    */
abstract class GameObject{
    public bool IsShared {get;protected set;} = true;
    public string Name = "";
    Action<Object> action;
    byte[] shape;
    public object Data;
}

}