using System;

namespace SignalR_GameServer_v1
{
  class WordPrototype : Word
  {
    public WordPrototype(string word)
    :base(word)
    {
    }
    //Shallow
    public override Word Clone()
    {
    
      return (Word)this.MemberwiseClone();
    }
    /*
    //Deep
    public override Word Clone()
    {
       Word other = (Word)this.MemberwiseClone();
       other.word = base.word;
       return other;
    }
    */
        public override void Add(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }
        public override String GetItem(int level)
        {
            throw new NotImplementedException();
        }

  }
}