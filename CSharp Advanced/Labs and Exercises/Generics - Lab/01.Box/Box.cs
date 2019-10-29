using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> things;
        public Box()
        {
            this.things = new List<T>();
        }

        public int Count => things.Count;

        public void Add(T element)
        {
            things.Add(element);
        }
        public T Remove()
        {
            T element = things.Last();

            this.things.RemoveAt(this.things.Count - 1);

            return element;
        }
    }
}
