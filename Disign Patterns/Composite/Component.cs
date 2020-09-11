using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace TemporaryProj.Composite
{
    /// <summary>
    /// Основополагающий класс для ветвей(Branch) и листьев(Data) дерева
    /// </summary>
    abstract class Component
    {
        /// <summary>
        /// Тут происходит весь обход дерева.
        /// </summary>
        /// <param name="action">Сюда в Component попадают листы дерева</param>
        public abstract void Operation(Action<Component> action);
        public string name { get; protected set; }
        public bool isBranch { get; protected set; }
        public Component(string name)
        {
            this.name = name;
        }
    }
}
