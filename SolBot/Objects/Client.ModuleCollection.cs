using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.Objects
{
    public partial class Client
    {
        public class ModuleCollection
        {
            public ModuleCollection(Objects.Client c)
            {
                this.Client = c;
                this.Healer = new Modules.Healer(c, 500, 400, 700);
                this.Alarms = new Modules.Alarms(c);
                this.RuneMaker = new Modules.RuneMaker(c);
                this.AutoSpeed = new Modules.AutoSpeed(c);
                this.AutoFisher = new Modules.AutoFisher(c);
                this.Targeting = new Modules.Targeting(c);
                this.FoodEater = new Modules.FoodEater(c);
                this.TrainPoints = new Modules.TrainPoints(c);
            }

            public Objects.Client Client { get; private set; }
            public Modules.Healer Healer { get; private set; }
            public Modules.Alarms Alarms { get; private set; }
            public Modules.RuneMaker RuneMaker { get; private set; }
            public Modules.AutoSpeed AutoSpeed { get; private set; }
            public Modules.AutoFisher AutoFisher { get; private set; }
            public Modules.Targeting Targeting { get; private set; }
            public Modules.FoodEater FoodEater { get; private set; }
            public Modules.TrainPoints TrainPoints { get; private set; }

        }

    }
}
