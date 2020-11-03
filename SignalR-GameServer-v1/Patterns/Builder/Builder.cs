using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    class Shop
    {
        public void Construct(TalismanBuilder talismanBuilder)
        {
            talismanBuilder.BuildMaterial();
            talismanBuilder.BuildAddPoints();
            talismanBuilder.BuildChance();
            talismanBuilder.BuildPrice();
            talismanBuilder.BuildRemovePoints();
        }
    }

    abstract class TalismanBuilder
    {
        protected Talisman talisman;

        public Talisman Talisman
        {
            get { return talisman; }
        }

        public abstract void BuildMaterial();
        public abstract void BuildPrice();
        public abstract void BuildAddPoints();
        public abstract void BuildRemovePoints();
        public abstract void BuildChance();
    }

    class GoldTalismanBuilder : TalismanBuilder
    {
        public GoldTalismanBuilder()
        {
            talisman = new Talisman("GoldTalisman");
        }

        public override void BuildMaterial()
        {
            talisman["material"] = "Gold";
        }
        public override void BuildPrice()
        {
            talisman["price"] = "25";
        }
        public override void BuildAddPoints()
        {
            talisman["addPoints"] = "3";
        }
        public override void BuildRemovePoints()
        {
            talisman["removePoints"] = "0";
        }
        public override void BuildChance()
        {
            talisman["chance"] = "3";
        }
    }

    class SilverTalismanBuilder : TalismanBuilder
    {
        public SilverTalismanBuilder()
        {
            talisman = new Talisman("SilverTalisman");
        }

        public override void BuildMaterial()
        {
            talisman["material"] = "Silver";
        }
        public override void BuildPrice()
        {
            talisman["price"] = "15";
        }
        public override void BuildAddPoints()
        {
            talisman["addPoints"] = "2";
        }
        public override void BuildRemovePoints()
        {
            talisman["removePoints"] = "0";
        }
        public override void BuildChance()
        {
            talisman["chance"] = "2";
        }
    }

    class BronzeTalismanBuilder : TalismanBuilder
    {
        public BronzeTalismanBuilder()
        {
            talisman = new Talisman("BronzeTalisman");
        }

        public override void BuildMaterial()
        {
            talisman["material"] = "Bronze";
        }
        public override void BuildPrice()
        {
            talisman["price"] = "10";
        }
        public override void BuildAddPoints()
        {
            talisman["addPoints"] = "1";
        }
        public override void BuildRemovePoints()
        {
            talisman["removePoints"] = "0";
        }
        public override void BuildChance()
        {
            talisman["chance"] = "1";
        }
    }


    class Talisman
    {
        private string _talismanType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();


        public Talisman(string talismanType)
        {
            this._talismanType = talismanType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Talisman Type: {0}", _talismanType);
            Console.WriteLine(" #material : {0}", _parts["material"]);
            Console.WriteLine(" #price : {0}", _parts["price"]);
            Console.WriteLine(" #Add points: {0}", _parts["addPoints"]);
            Console.WriteLine(" #Remove points : {0}", _parts["removePoints"]);
            Console.WriteLine(" #Chance : {0}", _parts["chance"]);
        }

        public int ActivateTalisman()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10);

            if (_parts["material"] == "Gold")
            {
                if (randomNumber == 1 ||randomNumber == 5 || randomNumber == 8)
                {
                    return 3;
                }
            }
            else if (_parts["material"] == "Silver")
            {
                if (randomNumber == 1 ||randomNumber == 5)
                {
                    return 2;
                }
            }
            else if ((_parts["material"] == "Bronze"))
            {
                 if (randomNumber == 1)
                {
                    return 1;
                }
            }

            return 0;
        }

    }
}