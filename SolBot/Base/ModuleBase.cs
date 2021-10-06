using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolBot.Base
{
    public class ModuleBase
    {
        public static IntPtr CreateLParam(int x, int y)
        {
            return (IntPtr)(x | (y << 16));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public ModuleBase(Objects.Client c)
        {
            this.Client = c;
        }
        public Objects.Client Client { get; private set; }
        public bool IsRunning { get; private set; }
        Thread t;

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.Logic));
            this.t.IsBackground = true;
            this.t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
        }

        public virtual void Logic()
        {

        }
           
        
    }
}
