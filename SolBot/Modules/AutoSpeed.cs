using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SolBot.Modules
{
    public class AutoSpeed
    {
        public IntPtr CreateLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }
        public AutoSpeed(Objects.Client c)
        {
            this.Client = c;
            
        }
        public Objects.Client Client { get; private set; }
        /// <summary>
        /// Gets whether the healer is running or not.
        /// </summary>
        
        public bool IsRunning { get; private set; }
        public int MinHealth { get; set; }
        public int MinMana { get; set; }
        public int MinSpeed { get; set; }
        public Objects.Client.StdString Spell;
        Thread t;

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.AutoSpeedLogic));
            this.t.IsBackground = true;
            this.t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
        }
        public void AutoSpeedLogic()
        {
            while (this.IsRunning)
            {
                
                double mana = this.Client.Player.Mana;
                double health = this.Client.Player.Health;
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
                {
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x7B, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x7B, 0);

                    

                    Thread.Sleep(5000);
                }
                else
                {
                    double speed = this.Client.Player.Speed;

                    if (mana > MinMana && health > MinHealth && speed <= MinSpeed)
                    {
                        this.Client.Functions.SendTalk(Spell, new Objects.Client.StdString(""), 1, 0);
                        Thread.Sleep(1000);
                    }
                }
            }
        }

    }
}
