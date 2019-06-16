using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();


            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splidetInput = input.Split(" ");

                string comand = splidetInput[0];

                int number = int.Parse(splidetInput[1]);

                if(comand == "Delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if(number == numbers[i])
                        {
                            numbers.Remove(number);
                            i--;
                        }
                    }
                }
                else if (comand== "Insert")
                {
                    int position = int.Parse(splidetInput[2]);
                    numbers.Insert(position, number);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
