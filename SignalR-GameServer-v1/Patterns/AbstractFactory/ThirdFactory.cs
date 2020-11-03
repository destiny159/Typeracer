using System;

namespace SignalR_GameServer_v1
{
    public class ThirdFactory : AbstractFactory
    {
public override Car createCar()
        {
            return new Car(3,"ThirdCar");
        }
        public override Person createPerson()
        {
            return new Person(3,"ThirdPerson");
        }
        public override Plane createPlane()
        {
           return new Plane(3,"ThirdPlane");
        }
        public override Tank createTank()
        {
           return new Tank(3,"ThirdTank");
        }
    }
}
