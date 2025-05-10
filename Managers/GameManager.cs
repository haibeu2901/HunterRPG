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

        private void InitializeGame()
        {
            UserInterface.DisplayTitle("Hunter RPG");
            UserInterface.DisplayMessage("Welcome to Hunter RPG!");
            UserInterface.DisplayMessage("You are a hunter trying to survive in the wilderness.");

            // Create player
            UserInterface.DisplayMessage("Enter your name:");
            string hunterName = UserInterface.GetInput();
            hunter = new Hunter(hunterName);

            // Create world
            InitializeGameWorld();

            // Give player starting items
            hunter.AddItem(new Item("Hunting Knife", ItemType.Weapon, 10));
            hunter.AddItem(new Item("Wooden Bow", ItemType.Weapon, 20));
            hunter.AddItem(new Item("Jerky", ItemType.Food, 15));

            // Set player location
            hunter.CurrentLocation = gameWorld.Find(location => location.Type == LocationType.Camp);

            isRunning = true;
        }


    }
}
