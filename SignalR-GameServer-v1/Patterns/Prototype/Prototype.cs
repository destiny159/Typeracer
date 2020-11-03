using System;

namespace SignalR_GameServer_v1
{
  class WordPrototype : Word
  {
    public WordPrototype(string word)
    :base(word)
    {
    }

    public override Word Clone()
    {
      return (Word)this.MemberwiseClone();
    }
  }
}