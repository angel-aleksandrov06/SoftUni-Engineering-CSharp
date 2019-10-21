using System;
using System.Linq;

namespace Workshop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var doubleLinked = new DoubleLinkedList<int>();
            doubleLinked.AddFirst(2);
            doubleLinked.AddFirst(5);
            doubleLinked.AddFirst(6);
            doubleLinked.AddFirst(2);
            doubleLinked.AddFirst(8);
            doubleLinked.ForEach(Console.WriteLine);
        }
    }
}
