using System;

namespace SignalR_GameServer_v1
{
    class ConcreteObserver : Observer
    {
        private string _name;
        private int _observerState;
        private ConcreteSubject _subject; 

        // Constructor
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }
        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Player: {0} new round is {1}", _name, _observerState);
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}