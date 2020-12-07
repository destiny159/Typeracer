using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    abstract class AbstractChatroom

    {
        public abstract void Register(Player participant);

        public abstract void Send(
            string from, string to, string message);
    }
    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Player> _participants =
            new Dictionary<string, Player>();
        
        public override void Register(Player participant)
        {
            if (!_participants.ContainsValue(participant))

            {
                _participants[participant.username] = participant;
            }


            participant.Chatroom = this;
        }

        public override void Send(
            string from, string to, string message)
        {
            Player participant = _participants[to];


            if (participant != null)

            {
                participant.Receive(from, message);
            }
        }
    }
}