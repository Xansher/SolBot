using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static SolBot.WinAPI;
using InputType = SolBot.WinAPI.InputType;

namespace SolBot.Modules
{
    public class AutoFisher
    {
        private static IntPtr CreateLParam(int x, int y)
        {
            return (IntPtr)(x | (y << 16));
        }

        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        //public static int CreateLParam(int x, int y) => (y << 16) | (x & 0xFFFF);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public AutoFisher(Objects.Client c)
        {
            this.Client = c;
        }

        public Objects.Client Client { get; private set; }
        public bool IsRunning { get; private set; }
        public int food = 0;

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

                
                if (this.Client.TibiaProcess.MainWindowTitle.Contains("Kasteria"))
                {
                    /*
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x78, 0);

                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, 1, CreateLParam(70, 21));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, 0, CreateLParam(71, 21));
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x78, 0);
                    Thread.Sleep(1100);
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, 0x78, 0);
                    
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, 1, CreateLParam(1350, 400));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, 0, CreateLParam(1351, 401));
                    WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, 0x78, 0);
                    Thread.Sleep(1100);*/
                }
                else if(this.Client.TibiaProcess.MainWindowTitle.Contains("Tibijka"))
                {
                    
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, (IntPtr)VK_F1, (IntPtr)0);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, (IntPtr)VK_F1, (IntPtr)0);
                    Random r = new Random();
                    int x = r.Next(824, 1065);
                    int y = r.Next(494, 681);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, (IntPtr)0x0, CreateLParam(x, y));

                    //food 
                    // Thread.Sleep(1000);
                    if (this.food == 40)
                    {
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(1200, 288));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x1, CreateLParam(1200, 288));
                        PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(1200, 288));
                        this.food = 0;
                    }
                  
                    Thread.Sleep(1000);
                    this.food++;
                }
                else if (this.Client.TibiaProcess.MainWindowTitle.Contains("Dragon Ball Legend"))
                {

                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, (IntPtr)VK_F4, (IntPtr)0);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, (IntPtr)VK_F4, (IntPtr)0);
                    Random r = new Random();
                    int x = r.Next(824, 1065);
                    int y = r.Next(555, 681);
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, (IntPtr)0x0, CreateLParam(x, y));

                    Thread.Sleep(200+ r.Next(100,200));
                    
                }
                else
                {
                    
                    
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(1765, 340));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x2, CreateLParam(1765, 340));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(1765, 340));
                    //Thread.Sleep(500);
                    //  PostMessage((IntPtr)0x0070C2A, 0x0084, (IntPtr)0x0, CreateLParam(1569, 560));
                    // PostMessage((IntPtr)0x0070C2A, 0x0020, (IntPtr)0x0, CreateLParam(1569, 560));

                    Random r = new Random();
                    int x = r.Next(860, 1391);
                    int y = r.Next(540, 836);

                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x201, (IntPtr)0x1, CreateLParam(x, y));
                    PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x202, (IntPtr)0x0, CreateLParam(x, y));

                    //PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x0200, (IntPtr)0x0, CreateLParam(1636, 164));
                   // PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x204, (IntPtr)0x2, CreateLParam(1636, 164));
                   // PostMessage(this.Client.TibiaProcess.MainWindowHandle, 0x205, (IntPtr)0x0, CreateLParam(1636, 164));

                    // PostMessage((IntPtr)0x0070C2A, 0x0084, (IntPtr)0x0, CreateLParam(1362, 560));
                    //  PostMessage((IntPtr)0x0070C2A, 0x0020, (IntPtr)0x0, CreateLParam(1362, 560));
                    /*
                    Input[] inputs = new Input[]
                   {
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dx = 100,
                                dy = 100,
                                dwFlags = (uint)(MouseEventF.Move | MouseEventF.LeftDown),
                                dwExtraInfo = WinAPI.GetMessageExtraInfo()
                            }
                        }
                    },
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)MouseEventF.LeftUp,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                   };

                    SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
                    */
                    Thread.Sleep(1100);
                }
            }
        }
    }
}
