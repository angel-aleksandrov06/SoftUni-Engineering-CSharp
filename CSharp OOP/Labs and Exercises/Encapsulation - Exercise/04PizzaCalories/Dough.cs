using System;

namespace _04PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechType, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!DoughValidator.isValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!DoughValidator.isValidBakingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.Weight
                * 2
                * DoughValidator.GetTechniqueModifier(this.BakingTechnique)
                * DoughValidator.GetFlourModifier(this.FlourType);
        }
    }
}
