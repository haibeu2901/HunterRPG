using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;
using HunterRPG.Managers;

namespace HunterRPG.Models
{
    internal class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationType Type { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Location> Connections { get; set; }

        public Location(string name, string description, LocationType type)
        {
            Name = name;
            Description = description;
            Type = type;
            Animals = new List<Animal>();
            Items = new List<Item>();
            Connections = new Dictionary<string, Location>();
        }

        public void AddConnection(string name, Location location)
        {
            Connections[name] = location;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public void DisplayDetails()
        {
            UserInterface.DisplayMessage($"Location: {Name}");
            UserInterface.DisplayMessage(Description);

            if (Animals.Count > 0)
            {
                UserInterface.DisplayMessage("Animals:");
                foreach (var animal in Animals)
                {
                    UserInterface.DisplayMessage($"  {animal.Name} (Health: {animal.Health})");
                }
            }

            if (Items.Count > 0)
            {
                UserInterface.DisplayMessage("Items:");
                foreach (var item in Items)
                {
                    UserInterface.DisplayMessage($"  {item.Name}");
                }
            }

            UserInterface.DisplayMessage("Connections:");
            foreach (var connection in Connections)
            {
                UserInterface.DisplayMessage($"  {connection.Key}: {connection.Value.Name}");
            }
        }
    }
}
