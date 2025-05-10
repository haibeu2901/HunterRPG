using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;
using HunterRPG.Models;

namespace HunterRPG.Managers
{
    internal class GameManager
    {
        private Hunter hunter;
        private List<Location> gameWorld;
        private bool isRunning;
        private int day;

        public GameManager()
        {
            gameWorld = new List<Location>();
            isRunning = false;
            day = 1;
        }

        public void Start()
        {
            InitializeGame();
            GameLoop();
        }

        

        
    }
}
