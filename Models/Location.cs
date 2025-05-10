using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;

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
    }
}
