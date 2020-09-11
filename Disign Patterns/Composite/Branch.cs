using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Composite
{
    /// <summary>
    /// Ветвь дерева, может содержать как другие ветви, так и листья(Data) одновременно 
    /// </summary>
    class Branch : Component
    {
        ArrayList childs;

        public override void Operation(Action<Component> action)
        {
            Console.WriteLine(name);
            foreach (Component a in childs)
                a.Operation(action);
        }
        public Branch(string name) : base(name)
        {
            childs = new ArrayList();
            isBranch = true;
        }
        public void AddChild(Component component)
        {
            childs.Add(component);
        }
        public void RemoveChild(Component component)
        {
            childs.Remove(component);
        }
        public Component GetChild(int index)
        {
            return childs[index] as Component;
        }
    }
}
