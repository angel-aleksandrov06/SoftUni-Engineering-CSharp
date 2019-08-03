using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var splitedInput = input.Split(" ");

                var command = splitedInput[0];

                if (command == "Translate")
                {
                    var theChar = splitedInput[1];
                    var replacement = splitedInput[2];

                    text = text.Replace(theChar, replacement);

                    Console.WriteLine(text);

                }
                else if (command == "Includes")
                {
                    var checkString = splitedInput[1];

                    if (text.Contains(checkString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Start")
                {
                    var checkString = splitedInput[1];
                    bool isValid = true;

                    for (int i = 0; i < checkString.Length; i++)
                    {
                        if (checkString[i] == text[i])
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Lowercase")
                {
                    text = text.ToLower();

                    Console.WriteLine(text);

                }
                else if (command == "FindIndex")
                {
                    var theChar = splitedInput[1];

                    var symbolIndex = text.LastIndexOf(theChar);

                    Console.WriteLine(symbolIndex);
                }
                else if (command == "Remove")
                {
                    int startIndex = int.Parse(splitedInput[1].ToString());
                    var count = int.Parse(splitedInput[2].ToString()); ;

                    text = text.Remove(startIndex, count);

                    Console.WriteLine(text);
                }

                input = Console.ReadLine();
            }
        }
    }
}
