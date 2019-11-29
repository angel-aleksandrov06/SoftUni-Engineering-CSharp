namespace _03WildFarm.Models.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            protected set { foodEaten = value; }
        }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);

        protected void BaseEat(Food food, List<string> eatableFood, double gainValue)
        {
            string typeFood = food.GetType().Name;

            if (!eatableFood.Contains(typeFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }

            this.Weight += food.Quantity * gainValue;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.name}, ";
        }
    }
}
