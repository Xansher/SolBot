using SolBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;

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
                    Thread.Sleep(100);

                    /*if(!Keyboard.IsKeyDown(Key.LeftCtrl) || !Keyboard.IsKeyDown(Key.RightCtrl) || !Keyboard.IsKeyDown(Key.LeftShift) || !Keyboard.IsKeyDown(Key.RightShift))
                    {
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(855, 333));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(855, 333));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(855, 333));
                        Thread.Sleep(100);
                    }*/


                    Thread.Sleep(6000);

                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Realesta") || this.Client.TibiaProcess.MainWindowTitle.Contains("Realera"))
                {
                    int x = 1835;
                    int y = 370;
                    int x2 = 933;
                    int y2 = 490;
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
                    Thread.Sleep(5000);
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x2, y2));
                    //Thread.Sleep(100);
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x2, y2));
                    //Thread.Sleep(100);
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(x2, y2));
                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(x2, y2));

                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("DBKO"))
                {
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F2, 0);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F2, 0);
                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Dragon Ball Legend"))
                {
                    if (this.Client.Player.Target != 0 && this.Client.Player.Health > this.Client.Modules.Healer.Health)
                    {
                        Random rand = new Random();
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F7, 0);
                        WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F7, 0);
                        Thread.Sleep(200 + rand.Next(97, 256));
                    }
                }


                //Thread.Sleep(10000);
            }
            
        }
    }
}
