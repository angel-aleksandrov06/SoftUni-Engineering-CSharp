using System;

namespace _04PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get 
            { 
                return this.type; 
            }
            private set 
            {
                if (!ToppingValidator.IsValid(value))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value; 
            }
        }

        public double Weight
        {
            get 
            { 
                return this.weight; 
            }
            private set 
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value; 
            }
        }

        public  double GetTotalCalories()
        {
            return 2 * this.Weight * ToppingValidator.GetModifier(this.Type);
        }
    }
}
