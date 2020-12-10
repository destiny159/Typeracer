using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    class Originator
    {
        private List<Player> _state;
        public List<Player> State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state[0].username + " Points: " + _state[0].points);
                Console.WriteLine("State = " + _state[1].username + " Points: " + _state[1].points);
                Console.WriteLine("State = " + _state[2].username + " Points: " + _state[2].points);
                Console.WriteLine("State = " + _state[3].username + " Points: " + _state[3].points);
            }
        }
        
        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    class Memento
    {
        private List<Player> _state;
        public  Memento(List<Player> state)
        {
            this._state = state;
        }

        public List<Player> State
        {
            get { return _state; }
        }
    }

    class Caretaker
    {
        private Memento _memento;
        public Memento Memento

        {
            set { _memento = value; }

            get { return _memento; }
        }
    }
}