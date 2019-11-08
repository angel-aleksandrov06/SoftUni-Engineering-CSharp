using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var TypeofAnimal = input;
                var inputString = Console.ReadLine().Split();

                var name = inputString[0];
                var age = int.Parse(inputString[1]);
                var gender = inputString[2];

                try
                {
                    switch (TypeofAnimal)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender)); break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age)); break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age)); break;
                        default:
                            throw new ArgumentException("Invalid input!");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            animals.ForEach(Console.WriteLine);
        }
    }
}
