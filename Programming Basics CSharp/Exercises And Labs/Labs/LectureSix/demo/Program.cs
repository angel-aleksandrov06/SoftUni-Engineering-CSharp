using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n   = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int a = 0; a< n; a++)
            {
                int number = int.Parse(Console.ReadLine());
                sum = sum + number;
            }
            Console.WriteLine(sum);
        }
    }
}
