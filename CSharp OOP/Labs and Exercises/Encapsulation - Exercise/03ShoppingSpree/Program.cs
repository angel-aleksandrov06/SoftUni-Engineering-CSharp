using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                var inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < inputPeople.Length; i++)
                {
                    var currentPerson = inputPeople[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                    var name = currentPerson[0];
                    decimal money = decimal.Parse(currentPerson[1]);
                    Person person = new Person(name, money);

                    people.Add(person);
                }

                for (int i = 0; i < inputProducts.Length; i++)
                {
                    var currentProduct = inputProducts[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                    var name = currentProduct[0];
                    decimal cost = decimal.Parse(currentProduct[1]);
                    Product product = new Product(name, cost);

                    products.Add(product);
                }

                var input = Console.ReadLine();

                while (input != "END")
                {
                    var inputIfno = input.Split();

                    var nameOfPerson = inputIfno[0];
                    var nameOfProduct = inputIfno[1];

                    Person person = people.FirstOrDefault(x => x.Name == nameOfPerson);
                    Product product = products.FirstOrDefault(x => x.Name == nameOfProduct);

                    person.AddToBag(product);

                    input = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
