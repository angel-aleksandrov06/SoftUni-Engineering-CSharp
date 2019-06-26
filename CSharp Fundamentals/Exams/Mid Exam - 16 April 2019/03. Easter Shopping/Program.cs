using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Shops = Console.ReadLine().Split(" ").ToList();

            int couontCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < couontCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                
                if(command[0] == "Include")
                {
                    Shops.Add(command[1]);
                }

                else if (command[0] == "Visit")
                {
                    int numberOfShops = int.Parse(command[2]);
                    
                    if(numberOfShops>=0 && numberOfShops <= Shops.Count)
                    {
                        if (command[1] == "first")
                        {
                            for (int j = 0; j < numberOfShops; j++)
                            {
                                Shops.RemoveAt(0);
                            }
                        }
                        else if (command[1] == "last")
                        {
                            for (int k = 0; k < numberOfShops; k++)
                            {
                                Shops.RemoveAt(Shops.Count - 1);
                            }
                        }
                    }
                }

                else if(command[0] == "Prefer")
                {
                    int firstShopIndex = int.Parse(command[1]);
                    int secondShopIndex = int.Parse(command[2]);

                    bool firstIndexIsRight = firstShopIndex >= 0 && firstShopIndex < Shops.Count;
                    bool secondIndexIsRight = secondShopIndex >= 0 && secondShopIndex < Shops.Count;

                    if(firstIndexIsRight && secondIndexIsRight)
                    {
                        string firtsShop = Shops[firstShopIndex];
                        string secondShop = Shops[secondShopIndex];

                        Shops[firstShopIndex] = secondShop;
                        Shops[secondShopIndex] = firtsShop;
                    }
                }

                else if(command[0] == "Place")
                {
                    int numberOfShops = int.Parse(command[2]);

                    if (numberOfShops >= 0 && numberOfShops <= Shops.Count)
                    {
                        Shops.Insert(numberOfShops + 1, command[1]);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",Shops));
        }
    }
}
