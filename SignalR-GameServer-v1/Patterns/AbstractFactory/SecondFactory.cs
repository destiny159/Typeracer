using System;

namespace SignalR_GameServer_v1
{
    public class SecondFactory : AbstractFactory
    {
         public override Car createCar()
        {
            return new Car(2,"SecondCar");
        }
        public override Person createPerson()
        {
            return new Person(2,"SecondPerson");
        }
        public override Plane createPlane()
        {
           return new Plane(2,"SecondPlane");
        }
        public override Tank createTank()
        {
           return new Tank(2,"SecondTank");
        }
    }
}
