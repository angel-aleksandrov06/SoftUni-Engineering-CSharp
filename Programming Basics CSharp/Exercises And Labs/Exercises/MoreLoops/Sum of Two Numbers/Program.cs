using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int star = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;

            for (int i = star; i <= end; i++)
            {
                for (int j = star; j <= end; j++)
                {
                    sum = 0;
                    counter++;
                    sum = i + j;
                    if (sum == magic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magic})");
                        break;
                    }
                    
                }
                if (sum == magic)
                {
                    break;
                }
            }
            if(sum!=magic)
            Console.WriteLine($"{counter} combinations - neither equals {magic}");
        }
    }
}
