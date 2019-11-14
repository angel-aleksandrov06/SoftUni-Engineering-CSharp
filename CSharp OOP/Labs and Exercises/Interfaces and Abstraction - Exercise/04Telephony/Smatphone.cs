namespace _04Telephony
{
    using System;
    using System.Linq;

    public class Smatphone : ICallable, IBrowsable
    {
        public Smatphone()
        {

        }

        public void Call(string[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number.Any(char.IsLetter))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {number}");
                }
            }
        }

        public void Browse(string[] urls)
        {
            foreach (var url in urls)
            {
                if (url.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {url}!");
                }
            }
        }
    }
}
