using System;

namespace SignalR_GameServer_v1
{
    public abstract class AbstractFactory
    {
        public abstract Plane createPlane();
        public abstract Tank createTank();
        public abstract Car createCar();
        public abstract Person createPerson();
    }
}