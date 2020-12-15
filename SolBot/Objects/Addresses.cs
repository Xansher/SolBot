using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.Objects
{
    public class Addresses
    {
        public Addresses(Objects.Client c)
        {
            this.Client = c;
            this.Memory = new Objects.Memory(c);
            this.IsValid = this.SetAddresses(c);
            
        }

        public Objects.Client Client { get; private set; }
        public Objects.Memory Memory { get; private set; }

        public bool IsValid { get; private set; }

        public PlayerAddresses Player { get; private set; }


        public bool SetAddresses(Objects.Client c)
        {
            int baseAddress = c.TibiaProcess.MainModule.BaseAddress.ToInt32();

            this.Player = new PlayerAddresses();
            int add = baseAddress + 0x00687E80;
            this.Player.BaseAddress = add;
            this.Player.XPosOffset = 0xC;
            this.Player.YPosOffset = 0x10;
            this.Player.ZPosOffset = 0x14;
            this.Player.NameOffset = 0x20;
            this.Player.Mana = baseAddress + 0x00687E80;
            this.Player.ManaOff= 0x478;
            this.Player.Health = baseAddress + 0x00687E80;
            this.Player.HealthOff= 0x440;
            this.Player.LightObject= 0x278C73 + baseAddress;
            this.Player.LightFloor = 0x2826C9 + baseAddress;
            this.Player.Light = 0x48D518 + baseAddress + 0xA4;
            return true;

        }

        public class PlayerAddresses
        {
            public int BaseAddress { get; set; }
            public int XPosOffset { get; set; }
            public int YPosOffset { get; set; }
            public int ZPosOffset { get; set; }
            public int NameOffset { get; set; }
            public int Mana { get ; set; }
            public int ManaOff { get; set; }
            public int Health { get; set; }
            public int HealthOff { get; set; }
            public int LightObject { get; set; }
            public int LightFloor { get; set; }
            public int Light { get; set; }
            
            
        }
    }
}
