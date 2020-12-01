using System;

namespace SignalR_GameServer_v1
{
    abstract class State
    {
        public abstract void Handle(StateContext context);
    }

    class SummerState : State
    {
        private int counter = 3;

        public override void Handle(StateContext context)
        {
            counter--;
            if (counter == 0)
            {
                context.State = new AutumnState();
            }
        }
    }

    class AutumnState : State
    {
        private int counter = 3;

        public override void Handle(StateContext context)
        {
            counter--;
            if (counter == 0)
            {
                context.State = new WinterState();
            }
        }
    }

    class WinterState : State
    {
        private int counter = 3;

        public override void Handle(StateContext context)
        {
            counter--;
            if (counter == 0)
            {
                context.State = new SpringState();
            }
        }
    }

    class SpringState : State
    {
        private int counter = 3;

        public override void Handle(StateContext context)
        {
            counter--;
            if (counter == 0)
            {
                context.State = new SummerState();
            }
        }
    }

    class StateContext
    {
        private State _state;

        public StateContext(State state)
        {
            this.State = state;
        }

        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " +
                                  _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}