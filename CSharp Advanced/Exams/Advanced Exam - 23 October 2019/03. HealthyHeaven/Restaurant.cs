using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        private string name;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
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
            if (data.Any(x=>x.Name == name))
            {
                data.Remove(data.Find(x=>x.Name == name));
                return true;
            }
            return false;
        }
        public Salad GetHealthiestSalad()
        {
            Salad helthiest = data[0];

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].GetTotalCalories() < helthiest.GetTotalCalories())
                {
                    helthiest = data[i];
                }
            }
            return helthiest;
        }
        
        public string GenerateMenu()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {data.Count} salads: ");

            for (int i = 0; i < data.Count; i++)
            {
                sb.AppendLine(data[i].ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
