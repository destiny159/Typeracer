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
    public string pointsColor {get;set;}
    public string skin {get;set;}
    public Talisman talisman {get;set;}

    public PermissionProxy permissionProxy { get; set; }

    public Player()
    {
        permissionProxy = new PermissionProxy(); 
    }
    public bool commandPermission
    {
        get { return permissionProxy.getCommandPermission(); }
    }
    public bool shopPermission
    {
        get { return permissionProxy.getShopPermission(); }
    }
  }
}