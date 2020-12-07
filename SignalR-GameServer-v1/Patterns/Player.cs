using System;
using System.Collections.Generic;

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
    public string receivedEmoji {get;set;}
    public string receivedFrom { get; set; }
    public Talisman talisman {get;set;}
    
    private Chatroom _chatroom;

    public PermissionProxy permissionProxy { get; set; }

    public Player()
    {
        permissionProxy = new PermissionProxy(); 
        _chatroom = new Chatroom();
    }
    public bool commandPermission
    {
        get { return permissionProxy.getCommandPermission(); }
    }
    public bool shopPermission
    {
        get { return permissionProxy.getShopPermission(); }
    }
    
    public Chatroom Chatroom
    {
        set { _chatroom = value; }

        get { return _chatroom; }
    }
    
    public void Send(string to, string message)
    {
        _chatroom.Send(username, to, message);
    }
    
    public virtual void Receive(
        string from, string message)
    {
        receivedEmoji = message;
        receivedFrom = from;
        Console.WriteLine("{0} to {1}: '{2}'",
            from, username, message);
    }
  }
}