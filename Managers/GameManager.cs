using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Models;

namespace HunterRPG.Managers
{
    internal class GameManager
    {
        private Hunter hunter;
        private List<Location> world;
        private bool isRunning;
        private int day;

        public GameManager()
        {
            world = new List<Location>();
            isRunning = false;
            day = 1;
        }
    }
}
