using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;

namespace HunterRPG.Models
{
    internal class Animal
    {
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public List<Item> Drops { get; set; }

        public Animal(string name, AnimalType type, int health, int damage)
        {
            Name = name;
            Type = type;
            Health = health;
            Damage = damage;
            Drops = new List<Item>();

        }
    }
}
