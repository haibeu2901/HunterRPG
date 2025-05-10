using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Managers;

namespace HunterRPG.Models
{
    internal class Hunter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Hunger { get; set; }
        public List<Item> Inventory { get; set; }
        public Location CurrentLocation { get; set; }

        public Hunter(string name)
        {
            Name = name;
            Health = 100;
            Energy = 100;
            Hunger = 0;
            Inventory = new List<Item>();
        }

        public bool IsAlive => Health > 0;

        public void Rest()
        {
            Health = Math.Min(Health + 20, 100);
            Energy = Math.Min(Energy + 50, 100);
            Hunger = Math.Min(Hunger + 15, 100);
            UserInterface.DisplayMessage($"You rested. Health: {Health}, Energy: {Energy}, Hunger: {Hunger}");
        }
    }
}
