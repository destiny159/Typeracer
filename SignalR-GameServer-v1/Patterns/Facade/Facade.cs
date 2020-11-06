using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    class Facade
    {
        private AbstractFactory _two;
        private AbstractFactory _three;
        public Facade()
        {
            _two = new SecondFactory();
            _three = new ThirdFactory();
        }

        public List<Player> ChangeToSecondLevel(List<Player> playerList)
        {
            Console.WriteLine("\nReached second Level");

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].character == "FirstTank")
                {
                    Tank tank = _two.createTank();
                    playerList[i].character = tank.type;
                    playerList[i].characterKoeficient = tank.koeficient;
                }
                if (playerList[i].character == "FirstPerson")
                {
                    Person person = _two.createPerson();
                    playerList[i].character = person.type;
                    playerList[i].characterKoeficient = person.koeficient;
                }
                if (playerList[i].character == "FirstPlane")
                {
                    Plane plane = _two.createPlane();
                    playerList[i].character = plane.type;
                    playerList[i].characterKoeficient = plane.koeficient;
                }
                if (playerList[i].character == "FirstCar")
                {
                    Car car = _two.createCar();
                    playerList[i].character = car.type;
                    playerList[i].characterKoeficient = car.koeficient;
                }
            }

            return playerList;
        }
        public List<Player> ChangeToThirdLevel(List<Player> playerList)
        {
            Console.WriteLine("\nReached third Level");
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].character == "SecondTank")
                {
                    Tank tank = _three.createTank();
                    playerList[i].character = tank.type;
                    playerList[i].characterKoeficient = tank.koeficient;
                }
                if (playerList[i].character == "SecondPerson")
                {
                    Person person = _three.createPerson();
                    playerList[i].character = person.type;
                    playerList[i].characterKoeficient = person.koeficient;
                }
                if (playerList[i].character == "SecondPlane")
                {
                    Plane plane = _three.createPlane();
                    playerList[i].character = plane.type;
                    playerList[i].characterKoeficient = plane.koeficient;
                }
                if (playerList[i].character == "SecondCar")
                {
                    Car car = _three.createCar();
                    playerList[i].character = car.type;
                    playerList[i].characterKoeficient = car.koeficient;
                }
            }

            return playerList;
        }
    }
}