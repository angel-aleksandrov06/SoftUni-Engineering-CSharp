using System;

namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int spirit = 0;
            int totalPrice = 0;

            int ornament = 2;
            int treeSkirt = 5;
            int treeGarlands = 3;
            int treeLightsForOne = 15;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }

                if (i%2 == 0)
                {
                    int price = ornament * quantity;
                    spirit += 5;
                    totalPrice += price;
                }

                if(i%3 == 0)
                {
                    int price = (treeSkirt * quantity) + (treeGarlands * quantity);
                    spirit += 13;
                    totalPrice += price;
                }

                if(i%5 == 0)
                {
                    int price = treeLightsForOne * quantity;
                    totalPrice += price;
                    spirit += 17;

                    if (i%3 == 0)
                    {
                        spirit += 30;
                    }
                }

                if (i % 10 == 0)
                {
                    spirit -= 20;
                    int price = treeSkirt + treeLightsForOne + treeGarlands;
                    totalPrice += price;
                }
            }

            if (days % 10 == 0)
            {
                spirit -= 30;
                //Console.WriteLine("sjkvbwejk");
            }

            Console.WriteLine($"Total cost: {totalPrice}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
