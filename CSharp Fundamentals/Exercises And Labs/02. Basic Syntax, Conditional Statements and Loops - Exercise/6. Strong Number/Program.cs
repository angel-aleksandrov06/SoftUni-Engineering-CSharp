using System;

namespace _6._Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            int sum = 0;
            

            for (int i = 1; i <= numberAsString.Length; i++)
            {
                char symbol = numberAsString[numberAsString.Length - i];

                int number = (int)char.GetNumericValue(symbol);

                int product = 1;

                for (int k = 1; k <= number; k++)
                {
                    product *= k;
                }
                sum += product;
            }
            int introNumber = int.Parse(numberAsString);

            if (introNumber == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

    }
}
