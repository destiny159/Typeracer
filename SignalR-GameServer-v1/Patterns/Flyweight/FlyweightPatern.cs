using System;
using System.Collections;
using System.Collections.Generic;


namespace SignalR_GameServer_v1
{
   
    
    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();
        
        public FlyweightFactory()
        {
            flyweights.Add("RW", new RandomWords());

            flyweights.Add("RL", new RandomLetters());

            flyweights.Add("RS", new RandomSentence());
        }
        public Word GetFlyweight(string key)
        {
            return ((Word) flyweights[key]);
        }
    }
}