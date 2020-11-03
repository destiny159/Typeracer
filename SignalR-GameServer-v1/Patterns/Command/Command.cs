using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{

    abstract class Command
    {
        protected List<Player> playerList;

        public Command(List<Player> playerList)
        {
            this.playerList = playerList;
        }
        public abstract void Execute();
    }


    class PenaltyCommand : Command
    {
        public PenaltyCommand(List<Player> playerList) :
          base(playerList)
        {
        }
        public override void Execute()
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                playerList[i].points--;
            }
        }
    }

    class UnlockAbilityCommand : Command
    {
        public UnlockAbilityCommand(List<Player> playerList) :
          base(playerList)
        {
        }
        public override void Execute()
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                playerList[i].isAbilityUsed=false;
            }
        }
    }

    class PrizeCommand : Command
    {
        public PrizeCommand(List<Player> playerList) :
          base(playerList)
        {
        }
        public override void Execute()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            playerList[randomNumber].points++;
            Console.WriteLine(randomNumber);
        }
    }

    class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

}