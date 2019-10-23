using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private ICollection<Salad> data;

        private string name;

        public Restaurant(string name)
        {
            this.data = new List<Salad>();
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            foreach (var salad in data)
            {
                if (salad.Name == name)
                {
                    this.data.Remove(salad);
                    return true;
                }
            }
            return false;
        }
        public Salad GetHealthiestSalad()
        {
            Salad result = data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();

            return result;
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
