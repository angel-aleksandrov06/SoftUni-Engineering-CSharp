using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.products = new List<Vegetable>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int GetTotalCalories()
        {
            var result = 0;
            for (int i = 0; i < products.Count; i++)
            {
                result += products[i].Calories;
            }
            return result;
        }

        public int GetProductCount()
        {
            var count = products.Count;
            return count;
        }

        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            for (int i = 0; i < products.Count; i++)
            {
                sb.AppendLine(products[i].ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
