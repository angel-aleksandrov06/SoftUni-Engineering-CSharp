namespace _03WildFarm.Models.Animals
{
    using Foods;
    using System.Collections.Generic;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight )
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public abstract void ProduceSound();

        protected abstract double WeightMultiplier { get; }

        protected abstract ICollection<Food> AllowedFood  { get; }

        public virtual void Eat(Food food)
        {
            if (!AllowedFood.Contains(food))
            {
                //•	"{AnimalType} does not eat {FoodType}!"
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
        }
    }
}
