using System;

namespace SignalR_GameServer_v1
{
    public interface IPermission
    {
        void giveCommandPermission();
        void giveShopPermission();
        void takeCommandPermission();
        void takeShopPermission();
        bool getCommandPermission();
        bool getShopPermission();
    }

    class Permission : IPermission
    {
        private bool commands { get; set; } = false;
        private bool shop { get; set; } = false;

        public void giveCommandPermission()
        {
            Console.WriteLine("Commands proxy true");
            commands = true;
        }

        public void giveShopPermission()
        {
            Console.WriteLine("Shop proxy true");
            shop = true;
        }

        public void takeCommandPermission()
        {
            Console.WriteLine("Commands proxy false");
            commands = false;
        }

        public void takeShopPermission()
        {
            Console.WriteLine("Shop proxy false");
            shop = false;
        }

        public bool getCommandPermission()
        {
            return commands;
        }

        public bool getShopPermission()
        {
            return shop;
        }
    }

    class PermissionProxy : IPermission
    {
        private Permission _permissionVoter = new Permission();

        public void giveCommandPermission()
        {
            _permissionVoter.giveCommandPermission();
        }

        public void giveShopPermission()
        {
            _permissionVoter.giveShopPermission();
        }

        public bool getCommandPermission()
        {
            return _permissionVoter.getCommandPermission();
        }

        public bool getShopPermission()
        {
            return _permissionVoter.getShopPermission();
        }

        public void takeCommandPermission()
        {
            _permissionVoter.takeCommandPermission();
        }

        public void takeShopPermission()
        {
            _permissionVoter.takeShopPermission();
        }
    }
}