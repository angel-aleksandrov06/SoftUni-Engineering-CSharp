using System;
using System.Linq;

namespace _10.___Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> lengthFunc = (x, y) => x.Length == y;
            Func<string, string, bool> startsWithFunc = (name, pattern) => name.StartsWith(pattern);
            Func<string, string, bool> endsWithFunc = (name, pattern) => name.EndsWith(pattern);

            while (true)
            {
                var commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandParts[0];

                if (command == "Party!")
                {
                    break;
                }
                else if (command == "Remove")
                {
                    var condition = commandParts[1];
                    var param = commandParts[2];

                    if (condition == "Length")
                    {
                        var length = int.Parse(param);
                        inputNames = inputNames.Where(x => !lengthFunc(x, length)).ToList();
                    }
                    else if (condition == "StartsWith")
                    {
                        inputNames = inputNames.Where(x => !startsWithFunc(x, param)).ToList();
                    }
                    else if (condition == "EndsWith")
                    {
                        inputNames = inputNames.Where(x => !endsWithFunc(x, param)).ToList();
                    }
                }
                else if (command == "Double")
                {
                    var condition = commandParts[1];
                    var param = commandParts[2];

                    if (condition == "Length")
                    {
                        var length = int.Parse(param);
                        var tempNames = inputNames.Where(x => lengthFunc(x, length)).ToList();
                        MyAddRange(inputNames, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        var tempNames = inputNames.Where(x => startsWithFunc(x, param)).ToList();
                        foreach (var currentName in tempNames)
                        {
                            var index = inputNames.IndexOf(currentName);
                            inputNames.Insert(index + 1, currentName);
                        }
                    }
                    else if (condition == "EndsWith")
                    {
                        var tempNames = inputNames.Where(x => endsWithFunc(x, param)).ToList();
                        foreach (var currentName in tempNames)
                        {
                            var index = inputNames.IndexOf(currentName);
                            inputNames.Insert(index + 1, currentName);
                        }
                    }
                }
            }

            if (inputNames.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", inputNames)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void MyAddRange(System.Collections.Generic.List<string> inputNames, System.Collections.Generic.List<string> tempNames)
        {
            foreach (var currentName in tempNames)
            {
                var index = inputNames.IndexOf(currentName);
                inputNames.Insert(index + 1, currentName);
            }
        }
    }
}
