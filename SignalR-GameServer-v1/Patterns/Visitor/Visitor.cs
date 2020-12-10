using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    interface IVisitor
    {
        void Visit(Element element);
    }

    class FontSizeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Parameter parameter = element as Parameter;

            parameter.FontSize -= 0.1;
        }
    }

    class ColorVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Parameter parameter = element as Parameter;

            if (parameter.Color == "black")
            {
                parameter.Color = "red";
            }
            else
            {
                parameter.Color = "black";
            }
        }
    }

    class OpacityVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Parameter parameter = element as Parameter;

            parameter.Opacity -= 0.05;
        }
    }

    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    class Parameter : Element
    {
        private double _opacity;

        private double _fontSize;

        private string _color;

        public Parameter(double opacity, double fontSize,
            string color)
        {
            this._opacity = opacity;

            this._fontSize = fontSize;

            this._color = color;
        }

        public double Opacity
        {
            get { return _opacity; }

            set { _opacity = value; }
        }

        public double FontSize
        {
            get { return _fontSize; }

            set { _fontSize = value; }
        }

        public string Color
        {
            get { return _color; }

            set { _color = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class ParametersGroup
    {
        private List<Parameter> _employees = new List<Parameter>();

        public void Attach(Parameter parameter)

        {
            _employees.Add(parameter);
        }

        public void Detach(Parameter parameter)

        {
            _employees.Remove(parameter);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Parameter e in _employees)

            {
                e.Accept(visitor);
            }

            Console.WriteLine();
        }

        public Parameter getParameter(int i)
        {
            return _employees[i];
        }
    }
}