using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace SolBot.Modules
{
    public class Healer
    {

        private static IntPtr CreateLParam(int x, int y)
        {
            return (IntPtr)(x | (y << 16));
        }

        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public Healer(Objects.Client c, ushort checkInterval, ushort sleepMin, ushort sleepMax)
        {
            this.Client = c;
            //this.Criterias = new List<Criteria>();
            this.CheckInterval = checkInterval;
            this.SleepMin = sleepMin;
            this.SleepMax = sleepMax;
            this.Rand = new Random();
        }

         /// <summary>
        /// Gets the client associated with this object.
        /// </summary>
        public Objects.Client Client { get; private set; }
        /// <summary>
        /// Gets whether the healer is running or not.
        /// </summary>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// Gets or sets how often the player's health and mana values are checked in milliseconds.
        /// </summary>
        public ushort CheckInterval { get; set; }
        /// <summary>
        /// Gets or sets the minimum amount of time in milliseconds to sleep once an action is performed.
        /// </summary>
        public ushort SleepMin { get; set; }
        /// <summary>
        /// Gets or sets the maximum amount of time in milliseconds to sleep once an action is performed.
        /// </summary>
        public ushort SleepMax { get; set; }

        public int Mana { get; set; }
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the list of criterias.
        /// </summary>
        //private List<Criteria> Criterias { get; set; }
        private Random Rand { get; set; }
        Thread t;
        Thread m;
        

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.HealerLogic));
            this.t.IsBackground = true;
            this.t.Start();
            this.m = new Thread(new ThreadStart(this.HealerLogicMana));
            this.m.IsBackground = true;
            this.m.Start();
            
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
            this.m.Abort();
        }

        private void HealerLogic()
        {
            while (this.IsRunning)
            {
                double mana = this.Client.Player.Mana;
                double health = this.Client.Player.Health;
                

                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
                {
                    if (health < Health)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x7B, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x7B, 0);
                    }
                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Imperianic"))
                {
                    if (health < Health)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x7B, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x7B, 0);
                    }
                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Tibijka"))
                {
                    if (health < Health)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F12, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F12, 0);
                    }
                }
                else
                {
                    if (mana >= 40 && health < 450 && health > 300)
                    {
                        this.Client.Functions.SendTalk(new Objects.Client.StdString("exura gran"), new Objects.Client.StdString(""), 1, 0);
                        Thread.Sleep(100);
                    }
                    else if (mana >= 160 && health < 300)
                    {
                        this.Client.Functions.SendTalk(new Objects.Client.StdString("exura vita"), new Objects.Client.StdString(""), 1, 0);
                        Thread.Sleep(100);
                    }
                }
            }
        }
        private void HealerLogicMana()
        {
            while (this.IsRunning)
            {
                double mana = this.Client.Player.Mana;
                double health = this.Client.Player.Health;
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
                {
                    if (mana < Mana)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x79, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x79, 0);
                        Thread.Sleep(700);
                    }

                }
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Tibijka"))
                {
                    if (mana < Mana)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x79, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x79, 0);
                        Thread.Sleep(700);
                    }

                }
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Imperianic"))
                {
                    if (mana < Mana)
                    {
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(1550, 250));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x2, CreateLParam(1550, 250));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(1550, 250));

                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(860, 450));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, (IntPtr)0x1, CreateLParam(860, 450));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, (IntPtr)0x0, CreateLParam(860, 450));
                        Thread.Sleep(250);
                    }

                }
                
            }
        }


    }
}
