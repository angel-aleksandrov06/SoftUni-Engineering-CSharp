using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var list = new List<string>();

            var splitedInput = input.Split("&", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splitedInput)
            {
                var length = item.Length;
                bool isSymbolsValid = true;
                bool islengthValid = false;

                if (length == 16 || length == 25)
                {
                    islengthValid = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (!Char.IsLetterOrDigit(item[i]))
                        {
                            isSymbolsValid = false;
                            break;
                        }
                    }
                }

                if (islengthValid && isSymbolsValid)
                {

                    if (length == 16)
                    {
                        var sb = new StringBuilder();

                        if (char.IsLetter(item[0]))
                        {
                            var newSymbol = item[0].ToString().ToUpper();
                            sb.Append(newSymbol);
                        }
                        if (char.IsDigit(item[0]))
                        {
                            int oldDigitSymbol = int.Parse(item[0].ToString());
                            var newDigitSymbol = (9 - oldDigitSymbol).ToString();
                            sb.Append(newDigitSymbol);
                        }
                        
                        for (int i = 1; i < length; i++)
                        {
                            if (i % 4 == 0 && i != 16)
                            {
                                sb.Append('-');
                            }

                            if (char.IsLetter(item[i]))
                            {
                                var newSymbol = item[i].ToString().ToUpper();
                                sb.Append(newSymbol);
                            }
                            if (char.IsDigit(item[i]))
                            {
                                int oldDigitSymbol = int.Parse(item[i].ToString());
                                var newDigitSymbol = (9 - oldDigitSymbol).ToString();
                                sb.Append(newDigitSymbol);
                            }
                        }

                        list.Add(sb.ToString());
                    }

                    if (length == 25)
                    {
                        var sb = new StringBuilder();

                        if (char.IsLetter(item[0]))
                        {
                            var newSymbol = item[0].ToString().ToUpper();
                            sb.Append(newSymbol);
                        }
                        if (char.IsDigit(item[0]))
                        {
                            int oldDigitSymbol = int.Parse(item[0].ToString());
                            var newDigitSymbol = (9 - oldDigitSymbol).ToString();
                            sb.Append(newDigitSymbol);
                        }

                        for (int i = 1; i < length; i++)
                        {
                            if (i % 5 == 0 && i != 25)
                            {
                                sb.Append('-');
                            }

                            if (char.IsLetter(item[i]))
                            {
                                var newSymbol = item[i].ToString().ToUpper();
                                sb.Append(newSymbol);
                            }
                            if (char.IsDigit(item[i]))
                            {
                                int oldDigitSymbol = int.Parse(item[i].ToString());
                                var newDigitSymbol = (9 - oldDigitSymbol).ToString();
                                sb.Append(newDigitSymbol);
                            }
                        }

                        list.Add(sb.ToString());
                    }
                }
            }

            Console.WriteLine($"{string.Join(", ", list)}");
        }
    }
}
