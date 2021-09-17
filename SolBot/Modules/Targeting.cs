using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SolBot.Modules
{
    public class Targeting
    {
        public Targeting(Objects.Client c)
        {
            this.Client = c;

        }
       
        /// <summary>
        /// Gets the client associated with this object.
        /// </summary>
        public Objects.Client Client { get; private set; }
        /// <summary>
        /// Gets whether the healer is running or not.
        /// </summary>
        public bool IsRunning { get; private set; }
        Thread t;

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.TargetingLogic));
            this.t.IsBackground = true;
            this.t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
        }
        void TargetingLogic()
        {
            while (this.IsRunning)
            {
                /* WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_F10, 0);
                 WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_F10, 0);

                 Thread.Sleep(300);*/
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_RIGHT, 0);
                Thread.Sleep(1000);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_RIGHT, 0);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x100, WinAPI.VK_LEFT, 0);
                Thread.Sleep(1000);
                WinAPI.SendMessage(this.Client.TibiaProcess.MainWindowHandle, 0x101, WinAPI.VK_LEFT, 0);
            }
                
        }

    }
}
