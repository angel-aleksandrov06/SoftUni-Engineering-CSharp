namespace _03WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using _03WildFarm.Models.Foods;

    public class Hen : Bird
    {
        private const double HentWeight = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.AllowedFood = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };
        }

        protected override double WeightMultiplier => HentWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
