using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.Objects
{
    public class Player
    {

        public Player(Objects.Client c)
        {
            this.Client = c;
        }

        public Objects.Client Client { get; private set; }
        public string Name
        {
            get { return this.Client.Memory.ReadStdString(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.NameOffset); }
            set { }
        }
        public double Mana
        {
            get { return this.Client.Memory.ReadDouble(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.Mana)+ this.Client.Addresses.Player.ManaOff); }
            set { }
        }
        public double Health
        {
            get { return this.Client.Memory.ReadDouble(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.Health) + this.Client.Addresses.Player.HealthOff); }
            set { }
        }

        public double Soul
        {
            get { return this.Client.Memory.ReadDouble(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.SoulOff); }
            set { }
        }
        public int Speed
        {
            get { return this.Client.Memory.ReadInt32(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.SpeedOff); }
            set { }
        }
        public uint XPos
        {
            get { return this.Client.Memory.ReadUInt32(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.XPosOffset); }
            set { }
        }
        public uint YPos
        {
            get { return this.Client.Memory.ReadUInt32(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.YPosOffset); }
            set { }
        }
        public uint ZPos
        {
            get { return this.Client.Memory.ReadUInt16(this.Client.Memory.ReadInt32(this.Client.Addresses.Player.BaseAddress) + this.Client.Addresses.Player.ZPosOffset); }
            set { }
        }

        public void EnableLightHack()
        {
            byte[] codeCaveT = { 0x66, 0xB8, 0xFF, 0xD7 };
            this.Client.Memory.WriteBytes(this.Client.Addresses.Player.Light, codeCaveT);
            this.Client.Memory.WriteBytes(this.Client.Addresses.Player.LightFloor, codeCaveT);
            this.Client.Memory.WriteBytes(this.Client.Addresses.Player.LightObject, codeCaveT);
        }

    }
}
