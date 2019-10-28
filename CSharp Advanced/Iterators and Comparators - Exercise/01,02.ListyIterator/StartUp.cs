using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {

            var command = Console.ReadLine();

            var commandParts = command.Split().Skip(1).ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(commandParts);

            command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Move")
                {
                    var result = listyIterator.Move();
                    Console.WriteLine(result);
                }
                else if(command == "HasNext")
                {
                    var result = listyIterator.HasNext();
                    Console.WriteLine(result);
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", listyIterator));
                }

                command = Console.ReadLine();
            }
        }
    }
}
