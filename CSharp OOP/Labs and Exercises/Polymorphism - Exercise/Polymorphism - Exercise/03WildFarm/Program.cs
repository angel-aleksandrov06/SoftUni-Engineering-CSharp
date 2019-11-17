namespace _03WildFarm
{
    using System;
    using System.Collections.Generic;
    using Models.Foods;
    using Models.Animals;
    using Factories;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (input != "End")
            {
                var animalArgs = input
                    .Split();

                Animal animal = AnimalFactory.Create(animalArgs);

                var foodArgs = Console.ReadLine()
                    .Split();

                Food food = FoodFactory.CreateFood(foodArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
