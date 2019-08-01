using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = string.Empty;
            var input = Console.ReadLine();

            while (input != "End")
            {
                var splitedInput = input.Split(" ");
                var command = splitedInput[0];

                if (command == "Add")
                {
                    var newString = splitedInput[1];
                    str = str + newString;
                }
                else if (command == "Upgrade")
                {
                    var symbol = char.Parse(splitedInput[1]);
                    var sb = new StringBuilder();

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == symbol)
                        {
                            sb.Append((char)(str[i] + 1));
                        }
                        else
                        {
                            sb.Append(str[i]);
                        }
                    }
                    str = sb.ToString();
                }
                else if (command == "Print")
                {
                    Console.WriteLine(str);
                }
                else if (command == "Index")
                {
                    var symbol = char.Parse(splitedInput[1]);
                    var sb = new StringBuilder();
                    List<string> charList = new List<string>();
                    var index = -1;

                    for (int i = 0; i < str.Length; i++)
                    {
                        index = str.IndexOf(symbol, index+1);
                        if (index == -1)
                        {
                            break;
                        }
                        charList.Add(index.ToString());
                    }


                    if (charList.Count() != 0)
                    {
                        Console.WriteLine(string.Join(" ", charList));
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (command == "Remove")
                {
                    var del = splitedInput[1];
                    str = str.Replace(del, string.Empty);
                }

                input = Console.ReadLine();
            }
        }
    }
}
