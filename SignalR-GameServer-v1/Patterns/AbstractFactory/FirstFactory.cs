using System;

namespace SignalR_GameServer_v1
{
    public class FirstFactory: AbstractFactory
    {
        public override Car createCar()
        {
            return new Car(5,"FirstCar");
        }
        public override Person createPerson()
        {
            return  new Person(3,"FirstPerson");
        }
        public override Plane createPlane()
        {
            return new Plane(2,"FirstPlane");
        }
        public override Tank createTank()
        {
           return new Tank(4,"FirstTank");
        }
    }
}