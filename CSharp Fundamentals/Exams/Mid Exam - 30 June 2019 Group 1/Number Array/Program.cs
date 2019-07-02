using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(" ").Select(x=>int.Parse(x)).ToList();

            string command = Console.ReadLine();

            while (command!= "End")
            {
                string[] commandArgs = command.Split(" ");

                string type = commandArgs[0];

                if(type== "Switch")
                {
                    int indexNumber = int.Parse(commandArgs[1]);

                    if(indexNumber>=0 && indexNumber < inputNumbers.Count)
                    {
                        int theNumber = inputNumbers[indexNumber];

                        if (theNumber > 0)
                        {
                            theNumber = 0-theNumber;
                            inputNumbers[indexNumber] = theNumber;
                        }
                        else if (theNumber < 0)
                        {
                            theNumber = 0 + Math.Abs(theNumber);
                            inputNumbers[indexNumber] = theNumber;
                        }
                    }
                }

                if(type == "Change")
                {
                    int indexNumber = int.Parse(commandArgs[1]);
                    int valueNumber = int.Parse(commandArgs[2]);

                    if(indexNumber >= 0 && indexNumber < inputNumbers.Count)
                    {
                        inputNumbers.RemoveAt(indexNumber);
                        inputNumbers.Insert(indexNumber, valueNumber);
                    }

                }

                if(type == "Sum")
                {
                    string operation = commandArgs[1];

                    if(operation == "Negative")
                    {
                        int sumOfNegativesNumbers = 0;

                        for (int i = 0; i < inputNumbers.Count; i++)
                        {
                            if(inputNumbers[i]< 0)
                            {
                                sumOfNegativesNumbers += inputNumbers[i];
                            }
                        }
                        Console.WriteLine(sumOfNegativesNumbers);
                    }
                    else if(operation == "Positive")
                    {
                        int sumOfPositiveNumbers = 0;

                        for (int i = 0; i < inputNumbers.Count; i++)
                        {
                            if (inputNumbers[i] > 0)
                            {
                                sumOfPositiveNumbers += inputNumbers[i];
                            }
                        }
                        Console.WriteLine(sumOfPositiveNumbers);
                    }

                    else if(operation == "All")
                    {
                        int sumOfAllNumbers = 0;
                        sumOfAllNumbers = inputNumbers.Sum();

                        Console.WriteLine(sumOfAllNumbers);
                    }
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if(inputNumbers[i] >= 0)
                {
                    Console.Write(inputNumbers[i] + " ");
                }
                
            }
        }
    }
}
