using System;
using System.Linq;

namespace _04PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split()[1];

                var input = Console.ReadLine()
                .Split()
                .ToArray();

                string flourType = input[1];
                string backingTech = input[2];
                double weight = double.Parse(input[3]);

                Dough dough = new Dough(flourType, backingTech, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    var toppingInput = command
                        .Split()
                        .ToArray();

                    string toppingType = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
