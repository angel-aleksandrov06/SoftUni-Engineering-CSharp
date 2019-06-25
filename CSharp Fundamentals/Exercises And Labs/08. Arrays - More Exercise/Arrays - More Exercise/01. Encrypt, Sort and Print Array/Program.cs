using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrString = new string[n];
            int[] arrInt = new int[n];


            for (int i = 0; i < n; i++)
            {
                string incomeString = Console.ReadLine();
                int sumOfVowel = 0;

                for (int j = 0; j < incomeString.Length; j++)
                {

                    bool isCharVowel = incomeString[j] == 'a' || incomeString[j] == 'e' || incomeString[j] == 'i' || incomeString[j] == 'o' || incomeString[j] == 'u';
                    bool isCharVowelUpper = incomeString[j] == 'A' || incomeString[j] == 'E' || incomeString[j] == 'I' || incomeString[j] == 'O' || incomeString[j] == 'U';

                    if (isCharVowel || isCharVowelUpper)
                    {
                        int symbolNumber = (int)incomeString[j];
                        sumOfVowel += (symbolNumber * incomeString.Length);
                    }
                    else
                    {
                        int symbolNumber = (int)incomeString[j];
                        sumOfVowel += (symbolNumber / incomeString.Length);
                    }
                }
                arrString[i] = incomeString;
                arrInt[i] = sumOfVowel;
            }

            Array.Sort(arrInt);
            foreach (var item in arrInt)
            {
                Console.WriteLine(item);
            }
        }
    }
}
