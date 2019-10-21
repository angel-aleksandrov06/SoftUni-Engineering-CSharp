using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public int GreaterValuesThan(T targetItem)
            
        {
            int counter = 0;

            foreach (var value in this.Values)
            {
                if (value.CompareTo(targetItem) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
