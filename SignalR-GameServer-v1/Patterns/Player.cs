using System;

namespace SignalR_GameServer_v1
{
    class Player 
  {
    public string username {get;set;}
    public int points {get;set;}
    public bool isWinner {get;set;}
    public bool isLoser {get;set;}

    public string character {get;set;}
    public bool isAbilityUsed {get;set;}
    public int characterKoeficient {get;set;}
    public Talisman talisman {get;set;}

    public Player()
    {
      
    }
  }
}