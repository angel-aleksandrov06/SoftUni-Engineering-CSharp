using System;

namespace _3._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double Cash = double.Parse(Console.ReadLine());
            string nameOfGame = Console.ReadLine();
            double spent = 0;

            while (nameOfGame!="Game Time")
            {
                double price = 0;
                if (nameOfGame == "OutFall 4")
                {
                    price = 39.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else if (nameOfGame == "CS: OG")
                {
                    price = 15.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else if (nameOfGame == "Zplinter Zell")
                {
                    price = 19.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else if (nameOfGame == "Honored 2")
                {
                    price = 59.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else if (nameOfGame == "RoverWatch")
                {
                    price = 29.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else if (nameOfGame == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (Cash < price)
                    {
                        Console.WriteLine("Too Expensive");
                        nameOfGame = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                        Cash -= price;
                        spent += price;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                    nameOfGame = Console.ReadLine();
                    continue;
                }
                if (Cash <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                nameOfGame = Console.ReadLine();
            }

            
            if (Cash > 0)
            {
                Console.Write($"Total spent: ${spent:F2}. ");
                Console.Write($"Remaining: ${Cash:F2}");
            }
        }
    }
}
