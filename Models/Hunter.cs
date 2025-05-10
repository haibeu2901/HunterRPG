using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterRPG.Models
{
    internal class Hunter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Hunger { get; set; }
        public List<Item> Inventory { get; set; }
        
    }
}
