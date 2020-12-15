using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolBot.Modules
{
    public class RuneMaker
    {
        public RuneMaker(Objects.Client c)
        {
            this.Client = c;
        }
        public Objects.Client Client { get; private set; }
        public bool IsRunning { get; private set; }
        public int ManaLow;
        public int ManaHigh;
        public Objects.Client.StdString spell;
        

        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            Thread t = new Thread(new ThreadStart(this.RuneMakerLogic));
            t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
        }

        private void RuneMakerLogic()
        {
            Random rnd = new Random();
            int randomMana = rnd.Next(this.ManaLow, this.ManaHigh);
            while (this.IsRunning)
            {
                double mana = this.Client.Player.Mana;
                

                if (mana > randomMana)
                {
                    this.Client.Functions.SendTalk(spell, new Objects.Client.StdString(""), 1, 0);
                    Thread.Sleep(400);
                    randomMana = rnd.Next(this.ManaLow, this.ManaHigh);
                }
                   

            }
        }
    }
}
