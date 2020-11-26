using System;

namespace SignalR_GameServer_v1
{
    public class Car
    {
        public Car()
        {
        }

        public Car(int koeficient, string type)
        {
            this.koeficient = koeficient;
            this.type = type;
        }

        public int koeficient {get;set;}
        public string type {get;set;}
    }//labas
}