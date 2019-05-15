using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string  word= (Console.ReadLine());
            int sumPrime = 0;
            int sumNonPrime = 0;
            while (word!="stop")
            {
                int n = int.Parse(word);
                if (n<0)
                {
                    Console.WriteLine("Number is negative.");
                    word = Console.ReadLine();
                    continue;
                    
                }
                bool isPrime = true;
                int a = 0;

                if (n==1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = n; i >= 2; i--)
                    {
                        if (n % i == 0 && i!=n)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                

                if (isPrime)
                {
                    sumPrime += n;
                }
                else
                {
                    sumNonPrime += n;
                }
                word = Console.ReadLine();

            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");

        }
    }
}
