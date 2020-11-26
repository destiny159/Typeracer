using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SignalR_GameServer_v1
{
    class Composite : Word
    {
        private List<Word> _children = new List<Word>();
        
        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Word component)
        {
            _children.Add(component);
        }

        public override void Remove(Word component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            foreach (Word component in _children)
            {
                component.Display(depth + 2);
            }
        }
        public override Word Clone()
        {
            throw new NotImplementedException();
        }
    }

    class Leaf : Word
    {
        public Leaf(string name)
            : base(name)
        {
        }

        public static string leafWord = "";
        public static int leafCounter = 0;

        public override void Add(Word c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Word c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            leafWord += word;
            leafCounter++;
            Console.WriteLine(new String('+', depth) + word);
            Console.WriteLine("LEAF: "+leafWord);
            
            if (leafCounter % 3 == 0)
            {
                leafWord = "";
            }
        }

        public override Word Clone()
        {
            throw new NotImplementedException();
        }
    }
}