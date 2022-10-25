using SolBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolBot.Modules
{
    public class AntyAFK: ModuleBase
    {
        public AntyAFK(Objects.Client c) : base(c)
        {
        }

        public override void Logic()
        {
            while (this.IsRunning)
            {
                WinAPI.PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_CONTROL, (uint)0x011D0001);
                WinAPI.PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_RIGHT, (uint)0x014D0001);
                WinAPI.PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_RIGHT, (uint)0xC14D0001);
                WinAPI.PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_CONTROL, (uint)0xC11D0001);
                Thread.Sleep(500);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_LEFT, 0x014B0001);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_LEFT, 0x014B0001);
                Thread.Sleep(500);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_CONTROL, 0x014D0001);
                Thread.Sleep(1000*60*10);
            }

        }
    }
}
