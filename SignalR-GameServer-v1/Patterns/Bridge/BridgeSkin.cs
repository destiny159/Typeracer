
using System;

namespace SignalR_GameServer_v1
{
    class SkinAbstraction
    {
        protected SkinImplementor implementor;

        public SkinImplementor Implementor
        {
            set { implementor = value; }
        }

        public virtual string GetTankSkin()
        {
            return implementor.GetTankSkin();
        }
        public virtual string GetPlaneSkin()
        {
            return implementor.GetPlaneSkin();
        }
        public virtual string GetCarSkin()
        {
           return implementor.GetCarSkin();
        }
        public virtual string GetPersonSkin()
        {
           return implementor.GetPersonSkin();
        }
    }

    abstract class SkinImplementor
    {
        public abstract string GetTankSkin();
        public abstract string GetPlaneSkin();
        public abstract string GetCarSkin();
        public abstract string GetPersonSkin();
    }

    class SkinRefinedAbstraction : SkinAbstraction
    {
        public override string GetTankSkin()
        {
           return implementor.GetTankSkin();
        }
        public override string GetPlaneSkin()
        {
            return implementor.GetPlaneSkin();
        }
        public override string GetCarSkin()
        {
           return implementor.GetCarSkin();
        }
         public override string GetPersonSkin()
        {
           return implementor.GetPersonSkin();
        }
    }

    class ConcreteSkinImplementor : SkinImplementor
    {
        public override string GetTankSkin()
        {
            Console.WriteLine("tank skin");
            return "<img style='max-width:100px' src='https://cdn.discordapp.com/attachments/753258314535665734/774315154959106088/Senza-titolo-1.png'></img>";
        }
        public override string GetPlaneSkin()
        {
            Console.WriteLine("plane skin");
            return "<img style='max-width:100px' src='https://cdn.discordapp.com/attachments/753258314535665734/774412521691021342/plane.png'></img>";
        }
        public override string GetCarSkin()
        {
            Console.WriteLine("car skin");
           return "<img style='max-width:100px' src='https://cdn.discordapp.com/attachments/753258314535665734/774316427108155412/car.png'></img>";
        }
        public override string GetPersonSkin()
        {
            Console.WriteLine("person skin");
           return "<img style='max-width:100px' src='https://cdn.discordapp.com/attachments/753258314535665734/774315836562866176/soldier.png'></img>";
        }
    }
}