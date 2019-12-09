﻿namespace _03WildFarm.Models.Animals
{
    using System.Collections.Generic;

    using Foods;

    public class Mouse : Mammal
    {
        private const double GainValue = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Vegetable), nameof(Fruit) }, GainValue);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}