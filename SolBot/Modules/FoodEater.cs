using SolBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolBot.Modules
{
    public class FoodEater: ModuleBase
    {
        public FoodEater(Objects.Client c) : base(c)
        {
        }

        public override void Logic()
        {
            while (this.IsRunning)
            {
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Realera"))
                {
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                    Thread.Sleep(100);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                    Thread.Sleep(100);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));

                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Realesta"))
                {
                    int x = 1840;
                    int y = 340;
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x, y));
                    Thread.Sleep(100);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x, y));
                    Thread.Sleep(100);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x, y));

                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("DBKO"))
                {
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F2, 0);
                }


                Thread.Sleep(20000);
            }
            
        }
    }
}
