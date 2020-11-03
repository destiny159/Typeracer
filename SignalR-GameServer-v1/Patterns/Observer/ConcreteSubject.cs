using System;

namespace SignalR_GameServer_v1
{
    class ConcreteSubject : Subject
    {
        private int _subjectState;
        // Gets or sets subject state
        public int SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }
}