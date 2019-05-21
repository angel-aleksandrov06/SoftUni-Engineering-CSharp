using System;

namespace _6._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char firstSymbol = (char)('a'+i);
                        char secondSymbol = (char)('a'+j);
                        char thirdSymbol = (char)('a'+k);
                        Console.WriteLine($"{firstSymbol}{secondSymbol}{thirdSymbol}");
                    }
                }
            }
        }
    }
}
