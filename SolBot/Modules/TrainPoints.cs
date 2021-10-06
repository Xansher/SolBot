using SolBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolBot.Modules
{
    public class TrainPoints: ModuleBase
    {
        public TrainPoints(Objects.Client c) : base(c)
        {
        }

        public override void Logic()
        {
            while (this.IsRunning)
            {
               WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_RIGHT, 0x014D0001);
               Thread.Sleep(1000);
               WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_RIGHT, 0x014D0001);
               WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_LEFT, 0x014B0001);
               Thread.Sleep(1000);
               WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_LEFT, 0x014B0001);
              

                /* PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0, (IntPtr)0x100,(IntPtr) 0x28);
                 PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0, (IntPtr)0x101,(IntPtr) 0x27);
                  Thread.Sleep(1000);*/
            }

        }
    }
}
