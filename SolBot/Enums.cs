using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot
{
    public class Enums
    {
        public enum SafeMode : byte
        {
            Enabled = 0,
            Disabled = 1
        }
        public enum FightMode : byte
        {
            Offensive = 1,
            Balanced = 2,
            Defensive = 3
        }
        public enum FightStance : byte
        {
            Stand = 0,
            Follow = 1,
            FollowDiagonalOnly = 2,
            FollowStrike = 3,
            /// <summary>
            /// Tries to use the surroundings to get hit as little as possible
            /// </summary>
            FollowEconomic = 4,
            /// <summary>
            /// Waits for the target to come in range, useful against monsters who does not run on low health
            /// </summary>
            DistanceWait = 5,
            /// <summary>
            /// Actively stays out of range, useful against monsters who tend to run on low health
            /// </summary>
            DistanceFollow = 6
        }
    }

}
