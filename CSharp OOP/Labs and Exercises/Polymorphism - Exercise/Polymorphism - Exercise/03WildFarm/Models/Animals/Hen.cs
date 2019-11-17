namespace _03WildFarm.Models.Animals
{
    using System.Collections.Generic;

    using Foods;

    public class Hen : Bird
    {
        private const double GainValue = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Fruit), nameof(Vegetable), nameof(Seeds) }, GainValue);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
