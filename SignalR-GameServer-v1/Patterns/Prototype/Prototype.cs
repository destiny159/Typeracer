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
    
  }
}