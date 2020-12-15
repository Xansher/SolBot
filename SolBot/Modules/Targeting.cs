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
        
        public void Start()
        {
            if (this.IsRunning)
                return;
            this.IsRunning = true;
            Thread t = new Thread(new ThreadStart(TargetingLogic));
        }

        public void Stop()
        {
            if (!this.IsRunning)
                return;
            this.IsRunning = false;
            
        }
        void TargetingLogic()
        {

        }

    }
}
