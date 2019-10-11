using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.___Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> FuncFilterStartsWith = (names, parameter) => names.StartsWith(parameter);
            Func<string, string, bool> FuncFilterEndstsWith = (names, parameter) => names.EndsWith(parameter);
            Func<string, int, bool> lengthFunc = (x, y) => x.Length == y;
            Func<string, string, bool> FuncFilterContains = (names, parameter) => names.Contains(parameter);

            var dict = new Dictionary<string, List<string>>();

            var inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var inputCommand = Console.ReadLine();

            while (inputCommand != "Print")
            {
                var commandParts = inputCommand.Split(";");
                var command = commandParts[0];
                var filterType = commandParts[1];
                var filterParameter = commandParts[2];

                if (command == "Add filter")
                {
                    if (!dict.ContainsKey(filterType))
                    {
                        dict[filterType] = new List<string>();
                    }

                    dict[filterType].Add(filterParameter);
                }
                else if (command == "Remove filter")
                {
                    if (dict.ContainsKey(filterType))
                    {
                        dict[filterType].Remove(filterParameter);
                    }
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var kvp in dict)
            {
                if (kvp.Key == "Starts with")
                {
                    inputNames = StartsWith(FuncFilterStartsWith, inputNames, kvp);
                }
                else if (kvp.Key == "Ends with")
                {
                    inputNames = EndsWith(FuncFilterEndstsWith, inputNames, kvp);
                }
                else if (kvp.Key == "Length")
                {
                    inputNames = Length(lengthFunc, inputNames, kvp);
                }
                else if (kvp.Key == "Contains")
                {
                    inputNames = Contains(FuncFilterContains, inputNames, kvp);
                }
            }

            Console.WriteLine(string.Join(" ", inputNames));
        }

        private static string[] StartsWith(Func<string, string, bool> FuncFilterStartsWith, string[] inputNames, KeyValuePair<string, List<string>> kvp)
        {
            foreach (var parameter in kvp.Value)
            {
                inputNames = inputNames.Where(x => !FuncFilterStartsWith(x, parameter)).ToArray();
            }

            return inputNames;
        }

        private static string[] Contains(Func<string, string, bool> FuncFilterContains, string[] inputNames, KeyValuePair<string, List<string>> kvp)
        {
            foreach (var parameter in kvp.Value)
            {
                inputNames = inputNames.Where(x => !FuncFilterContains(x, parameter)).ToArray();
            }

            return inputNames;
        }

        private static string[] Length(Func<string, int, bool> lengthFunc, string[] inputNames, KeyValuePair<string, List<string>> kvp)
        {
            foreach (var parameter in kvp.Value)
            {
                var length = int.Parse(parameter);

                inputNames = inputNames.Where(x => !lengthFunc(x, length)).ToArray();
            }

            return inputNames;
        }

        private static string[] EndsWith(Func<string, string, bool> FuncFilterEndstsWith, string[] inputNames, KeyValuePair<string, List<string>> kvp)
        {
            foreach (var parameter in kvp.Value)
            {
                inputNames = inputNames.Where(x => !FuncFilterEndstsWith(x, parameter)).ToArray();
            }

            return inputNames;
        }
    }
}
