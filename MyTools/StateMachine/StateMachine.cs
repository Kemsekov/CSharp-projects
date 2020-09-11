using System;
using System.Collections.Generic;
using System.Text;

namespace TemporaryProj.StateMachine
{
    public class Father
    {
        public State State { get; set; } = new NeutralState();

        public void HandleMark(int mark)
        {
            State.HandleParams(this, mark);
            State.DoAction();
        }
    }
    public abstract class State
    {

        protected abstract void BadOption();
        protected abstract void GoodOption();

        public State(Action action)
        {
            DoAction = action;
        }
        public State()
        {

        }
        public Action DoAction;
        public Enum StateEnum { get; private set; }
        public abstract void HandleParams(Father father, int mark);
    }

    class AngryState : State
    {

        public AngryState(Action action) : base(action)
        {

        }

        protected override void BadOption()
        {
            Console.WriteLine("You pitty!");
        }

        protected override void GoodOption()
        {
            Console.WriteLine("Maybe you are still can be my son");
        }

        public override void HandleParams(Father father, int mark)
        {

            switch (mark)
            {
                case 5:
                    father.State = new NeutralState(GoodOption);
                    break;
                case 2:
                    father.State.DoAction = BadOption;
                    break;
            }

        }
    }

    class GladState : State
    {
        public GladState(Action action) : base(action)
        {

        }

        public override void HandleParams(Father father, int mark)
        {
            switch (mark)
            {
                case 5:
                    father.State = new HappyState(GoodOption);
                    break;
                case 2:
                    father.State = new NeutralState(BadOption);
                    break;
            }
        }

        protected override void BadOption()
        {
            Console.WriteLine("two is not big deal");
        }

        protected override void GoodOption()
        {
            Console.WriteLine("Keep it up son!");
        }
    }

    class PityState : State
    {
        public PityState(Action action) : base(action)
        {

        }


        public override void HandleParams(Father father, int mark)
        {
            switch (mark)
            {
                case 2:
                    father.State = new NeutralState(BadOption);
                    break;
                case 5:
                    father.State = new HappyState(GoodOption);
                    break;
            }
        }

        protected override void BadOption()
        {
            Console.WriteLine("Don't do it again");
        }

        protected override void GoodOption()
        {
            Console.WriteLine("А ты переживал!");
        }
    }

    class HappyState : State
    {
        public HappyState(Action action) : base(action)
        {

        }

        public override void HandleParams(Father father, int mark)
        {
            switch (mark)
            {
                case 2:
                    father.State = new PityState(BadOption);
                    break;
                case 5:
                    father.State.DoAction = GoodOption;
                    break;
            }
        }

        protected override void BadOption()
        {
            Console.WriteLine("Не волнуйся, всё нормально, у тебя вон сколько пятёрок было!");
        }

        protected override void GoodOption()
        {
            Console.WriteLine("Папа может гордиться тобой!");
        }
    }

    class NeutralState : State
    {
        public NeutralState(Action action) : base(action)
        {

        }

        public NeutralState()
        {
            DoAction += () => { Console.WriteLine("And where marks?"); };
        }

        public override void HandleParams(Father father, int mark)
        {
            switch (mark)
            {
                case 5:
                    father.State = new GladState(GoodOption);
                    break;
                case 2:
                    father.State = new AngryState(BadOption);
                    break;
            }
        }

        protected override void BadOption()
        {
            Console.WriteLine("Не разочаровывай меня!");
        }

        protected override void GoodOption()
        {
            Console.WriteLine("Неплохо");
        }
    }




}
