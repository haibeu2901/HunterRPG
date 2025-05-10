using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        private void InitializeGameWorld()
        {
            // Create locations
            var camp = new Location("Camp", "Your home base. A safe place to rest.", LocationType.Camp);
            var forest = new Location("Forest", "Dense woods full of wildlife.", LocationType.Forest);
            var river = new Location("River", "A flowing river with fish and fresh water.", LocationType.River);
            var clearing = new Location("Clearing", "An open area in the forest.", LocationType.Clearing);
            var cave = new Location("Cave", "A dark cave in the hillside.", LocationType.Cave);

            // Connect locations
            camp.AddConnection("north", forest);
            camp.AddConnection("east", river);

            forest.AddConnection("south", camp);
            forest.AddConnection("east", clearing);
            forest.AddConnection("north", cave);

            river.AddConnection("west", camp);
            river.AddConnection("north", clearing);

            clearing.AddConnection("west", forest);
            clearing.AddConnection("south", river);

            cave.AddConnection("south", forest);

            // Add animals to locations
            forest.AddAnimal(new Animal("Deer", AnimalType.Deer, 30, 5));
            forest.AddAnimal(new Animal("Rabbit", AnimalType.Rabbit, 10, 2));

            clearing.AddAnimal(new Animal("Deer", AnimalType.Deer, 30, 5));
            clearing.AddAnimal(new Animal("Wolf", AnimalType.Wolf, 40, 15));

            cave.AddAnimal(new Animal("Bear", AnimalType.Bear, 70, 25));

            river.AddAnimal(new Animal("Wolf", AnimalType.Wolf, 40, 15));

            // Add items to locations
            river.AddItem(new Item("Fishing Rod", ItemType.Tool, 10));
            clearing.AddItem(new Item("Berries", ItemType.Food, 10));

            // Add locations to world
            gameWorld.Add(camp);
            gameWorld.Add(forest);
            gameWorld.Add(river);
            gameWorld.Add(clearing);
            gameWorld.Add(cave);
        }

        private void GameLoop()
        {
            while (isRunning)
            {
                // Check game over conditions
                if (!hunter.IsAlive)
                {
                    UserInterface.DisplayMessage("Game Over! You have died.");
                    isRunning = false;
                    break;
                }

                // Display
                UserInterface.DisplayMessage($"\nDay {day}");
                hunter.DisplayStatus();
                hunter.CurrentLocation.DisplayDetails();
                DisplayActions();

                string action = UserInterface.GetInput().ToLower();
                ProcessAction(action);

                // Check if there still enough anergy for the day
                if (hunter.Energy <= 0)
                {
                    UserInterface.DisplayMessage("\nYou're too tired to continue. The day is over.");
                    day++;
                    hunter.Rest();

                    RespawnAnimals();
                }

                // Check hunger
                if (hunter.Hunger >= 100)
                {
                    hunter.TakeDamage(5);
                    UserInterface.DisplayMessage("You're starving! You lose 5 health.");
                }
            }

            UserInterface.DisplayMessage("\nThanks for playing Hunter RPG!");
        }

        private void DisplayActions()
        {
            UserInterface.DisplayMessage("\nActions:");
            UserInterface.DisplayMessage("  1. Move (north, south, east, west)");
            UserInterface.DisplayMessage("  2. Hunt [animal name]");
            UserInterface.DisplayMessage("  3. Gather [item name]");
            UserInterface.DisplayMessage("  4. Rest");
            UserInterface.DisplayMessage("  5. Eat [item name]");
            UserInterface.DisplayMessage("  6. Quit");
            UserInterface.DisplayMessage("\nEnter your action:");
        }

        private void ProcessAction(string input)
        {
            string[] parts = input.Split(' ');
            string action = parts[0];

            switch (action)
            {
                case "north":
                case "south":
                case "east":
                case "west":
                    Move(action);
                    break;
                case "hunt":
                    if (parts.Length > 1)
                    {
                        Hunt(string.Join(" ", parts.Skip(1)));
                    }
                    else
                    {
                        UserInterface.DisplayMessage("Hunt what? Please specify an animal.");
                    }
                    break;
                case "gather":
                    if (parts.Length > 1)
                    {
                        Gather(string.Join(" ", parts.Skip(1)));
                    }
                    else
                    {
                        UserInterface.DisplayMessage("Gather what? Please specify an item.");
                    }
                    break;
                case "rest":
                    hunter.Rest();
                    break;
                case "eat":
                    if (parts.Length > 1)
                    {
                        Eat(string.Join(" ", parts.Skip(1)));
                    }
                    else
                    {
                        UserInterface.DisplayMessage("Eat what? Please specify a food item.");
                    }
                    break;
                case "quit":
                    UserInterface.DisplayMessage("Are you sure you want to quit? (yes/no)");
                    if (UserInterface.GetInput().ToLower() == "yes")
                    {
                        isRunning = false;
                    }
                    break;
                default:
                    UserInterface.DisplayMessage("Invalid action. Try again.");
                    break;
            }
        }
    }
}
