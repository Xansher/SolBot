using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace SolBot.Modules
{
    public class RuneMaker
    {
        private static IntPtr CreateLParam(int x, int y)
        {
            return (IntPtr)(x | (y << 16));
        }

        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public RuneMaker(Objects.Client c)
        {
            this.Client = c;
        }
        public Objects.Client Client { get; private set; }
        public bool IsRunning { get; private set; }
        public int ManaLow;
        public int ManaHigh;
        public int Soul;
        public Objects.Client.StdString spell;
        Thread t;

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.RuneMakerLogic));
            this.t.IsBackground = true;
            this.t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
        }

        private void RuneMakerLogic()
        {
            Random rnd = new Random();
            int randomMana = rnd.Next(this.ManaLow, this.ManaHigh);
            while (this.IsRunning)
            {
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("DBKO"))
                {
                    double mana = this.Client.Player.Mana;
                    if (mana > randomMana)
                    {
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F1, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F1, 0);

                        Thread.Sleep(1500);
                        randomMana = rnd.Next(this.ManaLow, this.ManaHigh);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F3, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F3, 0);
                    }
                } 
                else
                {
                    double mana = this.Client.Player.Mana;
                    double soul = this.Client.Player.Soul;

                    if (mana > randomMana)
                    {
                        if (this.Client.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
                        {
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x70, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x70, 0);
                        }
                        else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Imperianic"))
                        {
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x70, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x70, 0);
                        }
                        else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Tibijka"))
                        {
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F2, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F2, 0);
                        }
                        else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Realesta"))
                        {
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F1, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F1, 0);
                        }
                        else
                        {
                            //this.Client.Functions.SendTalk(spell, new Objects.Client.StdString(""), 1, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F3, 0);
                            WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F3, 0);
                            Thread.Sleep(400);
                            /*    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                                Thread.Sleep(100);
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                                Thread.Sleep(100);
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                                Thread.Sleep(100);
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                                PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));*/
                        }
                        Thread.Sleep(700);
                        randomMana = rnd.Next(this.ManaLow, this.ManaHigh);

                    }
                }     

            }
        }
    }
}
