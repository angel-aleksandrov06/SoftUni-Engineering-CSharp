using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        CustomStack<int> stack = new CustomStack<int>();

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Push":
                    int[] elements = tokens.Skip(1)
                        .Select(i => i.Split(',').First())
                        .Select(int.Parse)
                        .ToArray();
                    stack.Push(elements);
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    break;
            }
        }

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}