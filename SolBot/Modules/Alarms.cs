using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;

namespace SolBot.Modules
{
    public class Alarms
    {
        public Alarms(Objects.Client c)
        {
            this.Client = c;
            
        }

        public Objects.Client Client { get; private set; }
        public bool IsRunning { get; private set; }
        public int HealthBelow;
        public void Start()
        {
            if (this.IsRunning) return;
            this.IsRunning = true;
            Thread t = new Thread(new ThreadStart(this.AlarmLogic));
            t.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning) return;
            this.IsRunning = false;
        }

        private void AlarmLogic()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            
            while (this.IsRunning)
            {
                double mana = this.Client.Player.Mana;
                double health = this.Client.Player.Health;
                if (health < this.HealthBelow)
                    synth.Speak("Low HP");

            }
        }
    }
}
