
using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    abstract class Subject
    {
        private static List<Observer> _observers = new List<Observer>();
        
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
        
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
    }
}