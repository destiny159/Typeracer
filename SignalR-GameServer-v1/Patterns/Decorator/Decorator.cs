using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
  
  abstract class Decorator : Player
  {
    protected Player player;

    public Decorator(Player player)
    {
      this.player = player;
    }
  }

  class WinnerLoser : Decorator
  {
    public WinnerLoser(Player player)
      : base(player)
    {
    }
    public void SetWinner()
    {
      player.isLoser = false;
      player.isWinner = true;
    }

    public void SetLoser()
    {
      player.isWinner = false;
      player.isLoser = true;
    }
  }
}