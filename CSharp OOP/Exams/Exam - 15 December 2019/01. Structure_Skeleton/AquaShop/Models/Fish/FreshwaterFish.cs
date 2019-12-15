using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish, IFish
    {
        private const int initializeSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = initializeSize;
        }

        public override void Eat()
        {
            this.Size += initializeSize;
        }
    }
}
