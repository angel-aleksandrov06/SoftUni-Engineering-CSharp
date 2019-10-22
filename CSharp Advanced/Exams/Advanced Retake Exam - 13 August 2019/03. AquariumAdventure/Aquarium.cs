using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private ICollection<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.fishInPool = new List<Fish>();
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (!this.fishInPool.Any(f => f.Name == fish.Name) && !(this.fishInPool.Count>=this.Capacity))
            {
                this.fishInPool.Add(fish);
            }
        }
        public bool Remove(string name)
        {
            return this.fishInPool.Remove(this.fishInPool.Where(f => f.Name == name).FirstOrDefault());
        }

        public Fish FindFish(string name)
        {
            return this.fishInPool.Where(f => f.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var fish in this.fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
