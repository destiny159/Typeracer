using System;

namespace SignalR_GameServer_v1
{
    public class Plane
    {
        public Plane()
        {
        }

        public Plane(int koeficient, string type)
        {
            this.koeficient = koeficient;
            this.type = type;
        }

        public int koeficient {get;set;}
        public string type {get;set;}
    }
}