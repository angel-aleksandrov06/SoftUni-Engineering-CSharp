using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class Plant : Decoration, IDecoration
    {
        private const int InitializeComfort = 5;
        private const decimal InitializePrice = 10;

        public Plant()
            : base(InitializeComfort, InitializePrice)
        {
        }
    }
}
