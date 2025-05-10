using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HunterRPG.Enums;
using HunterRPG.Utils;

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
            GenerateDrops();
        }

        private void GenerateDrops()
        {
            switch (Type)
            {
                case AnimalType.Deer:
                    Drops.Add(new Item("Venison", ItemType.Food, 30));
                    if (RandomGenerator.GetRandomNumber(1, 10) > 5)
                    {
                        Drops.Add(new Item("Deer Hide", ItemType.Material, 10));
                    }
                    break;
                case AnimalType.Rabbit:
                    Drops.Add(new Item("Rabbit Meat", ItemType.Food, 15));
                    if (RandomGenerator.GetRandomNumber(1, 10) > 7)
                    {
                        Drops.Add(new Item("Rabbit Fur", ItemType.Material, 5));
                    }
                    break;
                case AnimalType.Wolf:
                    Drops.Add(new Item("Wolf Meat", ItemType.Food, 20));
                    if (RandomGenerator.GetRandomNumber(1, 10) > 6)
                    {
                        Drops.Add(new Item("Wolf Pelt", ItemType.Material, 15));
                    }
                    break;
                case AnimalType.Bear:
                    Drops.Add(new Item("Bear Meat", ItemType.Food, 40));
                    if (RandomGenerator.GetRandomNumber(1, 10) > 4)
                    {
                        Drops.Add(new Item("Bear Hide", ItemType.Material, 25));
                    }
                    break;

            }
        }

        public bool IsAlive() => Health > 0;

        public int Attack()
        {
            return RandomGenerator.GetRandomNumber(0, Damage);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);

        }
    }
}
