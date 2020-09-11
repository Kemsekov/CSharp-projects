using System;
using System.Drawing;
using System.Collections.Generic;

namespace TemporaryProj.Flyweight{
    class GameObjectFactory{
        Dictionary<string,GameObject> gameObjects = new Dictionary<string, GameObject>();
        public GameObjectWrapper GetGameObject(string key){
            if(!gameObjects.ContainsKey(key))
                AddGameObject(key,new DefaultGameObject());
            return new GameObjectWrapper(gameObjects[key]);
        }
        public void AddGameObject(string key,GameObject obj){
            if(obj.IsShared)
            gameObjects.Add(key,obj);
        }
    }
}