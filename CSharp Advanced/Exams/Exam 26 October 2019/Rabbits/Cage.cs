using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity> rabbits.Count)
            {
                rabbits.Add(rabbit);
                Capacity--;
            }
        }

        public bool RemoveRabbit(string name)
        {
            if (rabbits.Any(x => x.Name == name))
            {
                rabbits.Remove(rabbits.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            while (rabbits.Any(x => x.Species == species))
            {
                rabbits.Remove(rabbits.Find(x => x.Species == species));
            }
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = rabbits.Where(x => x.Name == name).FirstOrDefault();

            rabbit.Available = false;

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbitsArray = rabbits.Where(x => x.Species == species).ToArray();

            for (int i = 0; i < rabbitsArray.Length; i++)
            {
                rabbitsArray[i].Available = false;
            }

            for (int j = 0; j < rabbits.Count; j++)
            {
                if (rabbits[j].Species == species)
                {
                    rabbits[j].Available = false;
                }
            }

            return rabbitsArray;
        }

        public int Count => rabbits.Count;

        public string Report()
        {
            var rabbitsNotSolded = rabbits.Where(x => x.Available == true);
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in rabbitsNotSolded)
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
