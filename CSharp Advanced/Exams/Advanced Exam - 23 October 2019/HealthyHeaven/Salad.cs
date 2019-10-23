using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private ICollection<Vegetable> products;

        private string name;

        public Salad(string name)
        {
            this.products = new List<Vegetable>();
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int GetTotalCalories()
        {
            var result = this.products.Sum(x => x.Calories);
            return result;
        }

        public int GetProductCount()
        {
            return this.products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Salad {this.name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (var item in products)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
