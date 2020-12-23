using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolBot.Modules
{
    public class Healer
    {

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
        /// <summary>
        /// Gets or sets the list of criterias.
        /// </summary>
        //private List<Criteria> Criterias { get; set; }
        private Random Rand { get; set; }
        Thread t;

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            this.t = new Thread(new ThreadStart(this.HealerLogic));
            this.t.IsBackground = true;
            this.t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
            this.t.Abort();
        }

        private void HealerLogic()
        {
            while (this.IsRunning)
            {
                double mana = this.Client.Player.Mana;
                double health = this.Client.Player.Health;
                if(mana>=40&& health<300)
                    this.Client.Functions.SendTalk(new Objects.Client.StdString("exura gran"), new Objects.Client.StdString(""), 1, 0);
                Console.Out.WriteLine(mana);
                Thread.Sleep(700);
            }
        }


    }
}
