using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofComands = int.Parse(Console.ReadLine());

            List<string> listOFGuests = new List<string>();

            for (int i = 0; i < numberofComands; i++)
            {
                string[] splitedComand = Console.ReadLine().Split(" ").ToArray();

                string name = splitedComand[0];

                if(splitedComand[2] == "going!")
                {
                    if (listOFGuests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                       listOFGuests.Add(name);
                    }
                }
                else if (splitedComand[2] == "not")
                {
                    if (listOFGuests.Contains(name))
                    {
                        listOFGuests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            for (int i = 0; i < listOFGuests.Count; i++)
            {
                Console.WriteLine(listOFGuests[i]);
            }
        }
    }
}
