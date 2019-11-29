namespace _03WildFarm.Models.Animals
{
    using System.Collections.Generic;

    using Foods;

    public class Cat : Feline
    {
        private const double GainValue = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Vegetable) }, GainValue);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
