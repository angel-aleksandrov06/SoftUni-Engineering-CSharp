using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int min = int.MaxValue;
            int max = int.MinValue;

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var commandElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int commandIndex = commandElements[0];

                switch (commandIndex)
                {
                    case 1:
                        int elementToAdd = commandElements[1];
                        stack.Push(elementToAdd);
                        if (elementToAdd > max)
                        {
                            max = elementToAdd;
                        }
                        if (elementToAdd < min)
                        {
                            min = elementToAdd;
                        }
                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            int removedElement = stack.Pop();


                            if (removedElement == max)
                            {
                                if (stack.Count > 0)
                                {
                                    max = stack.Max();
                                }
                                else
                                {
                                    max = int.MinValue;
                                }
                            }

                            if (removedElement == min)
                            {
                                if (stack.Count > 0)
                                {
                                    min = stack.Min();
                                }
                                else
                                {
                                    min = int.MaxValue;
                                }
                            }
                        }

                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(max);
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(min);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
