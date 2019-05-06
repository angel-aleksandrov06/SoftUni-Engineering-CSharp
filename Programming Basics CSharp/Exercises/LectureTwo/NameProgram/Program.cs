using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            double age = double.Parse(Console.ReadLine());

            // simple way
            Console.WriteLine("My name is " + firstName + " " +  secondName + " " + age);

            // String format {0}
            Console.WriteLine("2 My name is {0} {1} {2:F1}", firstName, secondName, age);

            // String  interpolation {variable}
            Console.WriteLine($"3 My name is { firstName} { secondName} {age:F1}");
        }
    }
}
