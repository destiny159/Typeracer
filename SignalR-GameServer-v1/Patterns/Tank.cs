using System;

namespace SignalR_GameServer_v1
{
    public class Tank
    {
        public Tank()
        {
        }

        public Tank(int koeficient, string type)
        {
            this.koeficient = koeficient;
            this.type = type;
        }

        public int koeficient {get;set;}
        public string type {get;set;}
    }
}