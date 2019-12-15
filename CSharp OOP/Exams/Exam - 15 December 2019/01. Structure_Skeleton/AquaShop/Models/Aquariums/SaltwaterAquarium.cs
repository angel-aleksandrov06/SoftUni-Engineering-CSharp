using AquaShop.Models.Aquariums.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium, IAquarium
    {
        private const int initializeCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, initializeCapacity)
        {
        }
    }
}
