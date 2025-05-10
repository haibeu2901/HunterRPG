using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;
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

        public void Eat(Item food)
        {
            if (food.Type == ItemType.Food)
            {
                Health = Math.Min(Health + 10, 100);
                Hunger = Math.Min(Hunger - food.Value, 100);
                UserInterface.DisplayMessage($"You ate {food.Name}. Health: {Health}, Hunger: {Hunger}");
                Inventory.Remove(food);
            }
            else
            {
                UserInterface.DisplayMessage($"You can't eat {food.Name}!");
            }
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
            UserInterface.DisplayMessage($"You acquired {item.Name}!");
        }

        public void UseEnergy(int amount)
        {
            Energy = Math.Max(Energy - amount, 0);
            Hunger = Math.Max(Hunger + amount / 2, 100);
        }

        public void DisplayStatus()
        {
            UserInterface.DisplayMessage($"Name: {Name}");
            UserInterface.DisplayMessage($"Health: {Health}/100");
            UserInterface.DisplayMessage($"Energy: {Energy}/100");
            UserInterface.DisplayMessage($"Hunger: {Hunger}/100");
            UserInterface.DisplayMessage($"Location: {CurrentLocation.Name}");
            UserInterface.DisplayMessage("Inventory:");
            if (Inventory.Count == 0)
            {
                UserInterface.DisplayMessage("Empty");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    UserInterface.DisplayMessage($"  {item.Name} ({item.Type})");
                }
            }
        }
    }
}
