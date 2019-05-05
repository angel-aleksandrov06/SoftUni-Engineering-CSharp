using System;

namespace Math_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <=30; c++)
                    {
                        int sum = 0;

                        if (a<b && b < c)
                        {
                            sum = a + b + c;
                            if (sum == key)
                            {
                                Console.WriteLine($"{a} + {b} + {c} = {key}");
                                counter++;
                            }

                        }
                        else if(a>b && b > c)
                        {
                            sum = a * b * c;
                            if (sum == key)
                            {
                                Console.WriteLine($"{a} * {b} * {c} = {key}");
                                counter++;
                            }
                        }

                        

                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
