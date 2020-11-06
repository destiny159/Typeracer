
using System;

namespace SignalR_GameServer_v1
{
    class PointsColorAbstraction
    {
        protected PointsColorImplementor implementor;

        public PointsColorImplementor Implementor
        {
            set { implementor = value; }
        }

        public virtual string GetRedPointsColor()
        {
            return implementor.GetRedPointsColor();
        }
        public virtual string GetBluePointsColor()
        {
            return implementor.GetBluePointsColor();
        }
        public virtual string GetGreenPointsColor()
        {
           return implementor.GetGreenPointsColor();
        }
    }

    abstract class PointsColorImplementor
    {
        public abstract string GetRedPointsColor();
        public abstract string GetBluePointsColor();
        public abstract string GetGreenPointsColor();
    }

    class PointsColorRefinedAbstraction : PointsColorAbstraction
    {
        public override string GetRedPointsColor()
        {
           return implementor.GetRedPointsColor();
        }
        public override string GetBluePointsColor()
        {
            return implementor.GetBluePointsColor();
        }
        public override string GetGreenPointsColor()
        {
           return implementor.GetGreenPointsColor();
        }
    }

    class ConcretePointsColorImplementor : PointsColorImplementor
    {
        public override string GetRedPointsColor()
        {
            Console.WriteLine("points color red");
            return "red";
        }
        public override string GetBluePointsColor()
        {
            Console.WriteLine("points color blue");
            return "blue";
        }
        public override string GetGreenPointsColor()
        {
            Console.WriteLine("points color green");
            return "green";
        }
    }
}