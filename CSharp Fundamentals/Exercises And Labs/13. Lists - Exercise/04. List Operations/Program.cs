using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitedInput = input.Split(" ");

                string comand = splitedInput[0];

                switch (comand)
                {
                    case "Add":
                        int number = int.Parse(splitedInput[1]);

                        numbers.Add(number);
                        break;
                    case "Insert":
                        number = int.Parse(splitedInput[1]);
                        int index = int.Parse(splitedInput[2]);

                        bool isIndexValid = IsIndexValid(index, 0, numbers.Count);
                        if (isIndexValid)
                        {
                            numbers.Insert(index, number);
                        }
                        
                        break;
                    case "Remove":
                        index = int.Parse(splitedInput[1]);

                        isIndexValid = IsIndexValid(index, 0, numbers.Count);
                        if (isIndexValid)
                        {
                            numbers.RemoveAt(index);
                        }

                        break;
                    case "Shift":
                        string direction = splitedInput[1];
                        int count = int.Parse(splitedInput[2]);

                        if(direction == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }

        static bool IsIndexValid(int index, int minRange, int maxRange)
        {
            if (index < minRange || index >= maxRange)
            {
                Console.WriteLine("Invalid index");
                return false;
            }

            return true;
        }
    }
}
