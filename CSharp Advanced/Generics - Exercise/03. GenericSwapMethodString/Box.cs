using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public void Swap(int a, int b)
        {
            var IsInRange = a >= 0 && a < this.Values.Count && b >= 0 && b < this.Values.Count;

            if (!IsInRange)
            {
                Console.WriteLine("Error!");
            }

            T tempValue = this.Values[a];
            this.Values[a] = this.Values[b];
            this.Values[b] = tempValue;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
