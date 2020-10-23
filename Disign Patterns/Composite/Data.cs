using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.Composite
{
    class Data<T> : Component
    {
        public T data { get; set; }
        public override void Operation(Action<Component> action)
        {
            action(this);
        }

        public override IEnumerator<Component> GetEnumerator()
        {
            yield return this;
        }

        public Data(string name) : base(name)
        {
            isBranch = false;
        }
        public Data(string name,T data) : base(name)
        {
            this.data = data;
            isBranch = false;
        }
    }
}
