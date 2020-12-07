using System;
using System.Collections;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    class InterpreterContext
    {
        private string _input;
        private string _output;

        public InterpreterContext(string input)
        {
            this._input = input;
        }
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    abstract class Expression
    {
        public void Interpret(InterpreterContext context)

        {
            if (context.Input.Length == 0)
            {
                return;
            }
            
            if (context.Input.StartsWith(EyesSimple()))
            {
                context.Output += "EyesSimple";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith(EyesGlasses()))
            {
                context.Output += "EyesGlasses";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith(MouthSmile()))
            {
                context.Output += "MouthSmile";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith(MouthLaugh()))
            {
                context.Output += "MouthLaugh";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith(MouthOpen()))
            {
                context.Output += "MouthOpen";
                context.Input = context.Input.Substring(1);
            }
        }


        public abstract string EyesSimple();

        public abstract string EyesGlasses();

        public abstract string MouthSmile();

        public abstract string MouthOpen();

        public abstract string MouthLaugh();
    }

    class EyesExpression : Expression
    {
        public override string EyesSimple()
        {
            return ":";
        }

        public override string EyesGlasses()
        {
            return "8";
        }

        public override string MouthSmile()
        {
            return " ";
        }

        public override string MouthOpen()
        {
            return " ";
        }

        public override string MouthLaugh()
        {
            return " ";
        }
    }
    
    class MouthExpression : Expression
    {
        public override string EyesSimple()
        {
            return " ";
        }

        public override string EyesGlasses()
        {
            return " ";
        }

        public override string MouthSmile()
        {
            return ")";
        }

        public override string MouthOpen()
        {
            return "O";
        }

        public override string MouthLaugh()
        {
            return "D";
        }
    }
}