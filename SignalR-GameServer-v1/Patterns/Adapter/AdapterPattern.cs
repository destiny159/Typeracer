
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SignalR_GameServer_v1
{
    class Target
    {
        public virtual string RequestUsername(string username)
        {
            Console.WriteLine("Called Target RequestUsername()");
            return "VirtualRequestUsername";
        }
    }

    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override string RequestUsername(string username)
        {
            if (username == "")
            {
                return _adaptee.RandomUsername();
            }
            else
            {
                return _adaptee.UsernameAutofill(username);
            }
        }
    }
    class Adaptee
    {
        public string RandomUsername()
        {
            var json = new WebClient().DownloadString("http://names.drycodes.com/1");
            dynamic stuff = JsonConvert.DeserializeObject(json);
            return stuff[0];
        }

        public string UsernameAutofill(string username)
        {
            var json = new WebClient().DownloadString("https://api.datamuse.com/words?sl="+username);
            dynamic stuff = JsonConvert.DeserializeObject(json);
            return stuff[0].word;
        }
    }
}