using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firtRow = Console.ReadLine().Split(" ").ToArray();
            string[] secondRow = Console.ReadLine().Split(" ").ToArray();

            for (int i = 0; i < secondRow.Length; i++)
            {
                for (int j = 0; j < firtRow.Length; j++)
                {
                    if(firtRow[j] == secondRow[i])
                    {
                        Console.Write(secondRow[i]+ " ");
                    }
                }
            }
        }
    }
}
