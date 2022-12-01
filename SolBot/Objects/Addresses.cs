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
            if (c.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
            {
                int add = baseAddress + 0x0082F150;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x0082F150;
                this.Player.ManaOff = 0x4A0;
                this.Player.Health = baseAddress + 0x0082F150;
                this.Player.HealthOff = 0x468;
                this.Player.SoulOff = 0x4C8;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
            else if (c.TibiaProcess.MainWindowTitle.Contains("Tibijka"))
            {
                int add = baseAddress + 0x0082F150;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x0096F870;
                this.Player.ManaOff = 0x448;
                this.Player.Health = baseAddress + 0x0096F870;
                this.Player.HealthOff = 0x410;
                this.Player.SoulOff = 0x470;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
            else if (c.TibiaProcess.MainWindowTitle.Contains("DBKO"))
            {
                int add = baseAddress + 0x00555178;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x00555178;
                this.Player.ManaOff = 0x480;
                this.Player.Health = baseAddress + 0x00555178;
                this.Player.HealthOff = 0x448;
                this.Player.SoulOff = 0x470;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
            else if (c.TibiaProcess.MainWindowTitle.Contains("Imperianic"))
            {
                int add = baseAddress + 0x0082F150;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x001B5F68;
                this.Player.ManaOff = 0xA10;
                this.Player.Health = baseAddress + 0x001B5F68;
                this.Player.HealthOff = 0x950;
                this.Player.SoulOff = 0x4C8;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
            else if (c.TibiaProcess.MainWindowTitle.Contains("Realesta") || c.TibiaProcess.MainWindowTitle.Contains("Realera"))
            {
                int add = baseAddress + 0x0095C060;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x0095C060;
                this.Player.ManaOff = 0x4C8;
                this.Player.Health = baseAddress + 0x0095C060;
                this.Player.HealthOff = 0x490;
                this.Player.SoulOff = 0x4F0;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
            else if (c.TibiaProcess.MainWindowTitle.Contains("Dragon Ball Legend"))
            {
                int add = baseAddress + 0x0060B2C0;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = add;
                this.Player.ManaOff = 0x430;
                this.Player.Health = add;
                this.Player.HealthOff = 0x3F8;
                this.Player.SoulOff = 0x4E0;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                this.Player.Target = baseAddress + 0x000B1224;
                this.Player.TargetOff = 0x1C;
                return true;
            }
            else 
            {
                int add = baseAddress + 0x00494A38;
                this.Player.BaseAddress = add;
                this.Player.XPosOffset = 0xC;
                this.Player.YPosOffset = 0x10;
                this.Player.ZPosOffset = 0x14;
                this.Player.NameOffset = 0x20;
                this.Player.Mana = baseAddress + 0x00494A38;
                this.Player.ManaOff = 0x3E8;
                this.Player.Health = baseAddress + 0x00494A38;
                this.Player.HealthOff = 0x3B0;
                this.Player.SoulOff = 0x410;
                this.Player.SpeedOff = 0xA8;
                this.Player.LightObject = 0x278C73 + baseAddress;
                this.Player.LightFloor = 0x2826C9 + baseAddress;
                this.Player.Light = 0x48D518 + baseAddress + 0xA4;
                return true;
            }
           

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
            public int SoulOff { get; set; } 
            public int SpeedOff { get; set; }
            public int LightObject { get; set; }
            public int LightFloor { get; set; }
            public int Light { get; set; }

            public int Target { get; set; }
            public int TargetOff { get; set; }

        }
    }
}
