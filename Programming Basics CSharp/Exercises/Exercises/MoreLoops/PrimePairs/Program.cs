using System;

namespace Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int startFirst = int.Parse(Console.ReadLine());
            int startSecond = int.Parse(Console.ReadLine());
            int diffFirst = int.Parse(Console.ReadLine());
            int diffSecond = int.Parse(Console.ReadLine());

            int stopFirst = startFirst + diffFirst;
            int stopSecond = startSecond + diffSecond;

            for (int i = startFirst; i <= stopFirst; i++)
            {
                for (int j = startSecond; j <= stopSecond; j++)
                {
                    switch (i)
                    {
                        case 11:
                        case 13:
                        case 17:
                        case 19:
                        case 23:
                        case 29:
                        case 31:
                        case 37:
                        case 41:
                        case 43:
                        case 47:
                        case 53:
                        case 59:
                        case 61:
                        case 67:
                        case 71:
                        case 73:
                        case 79:
                        case 83:
                        case 89:
                        case 97:
                            switch (j)
                            {
                                case 11:
                                case 13:
                                case 17:
                                case 19:
                                case 23:
                                case 29:
                                case 31:
                                case 37:
                                case 41:
                                case 43:
                                case 47:
                                case 53:
                                case 59:
                                case 61:
                                case 67:
                                case 71:
                                case 73:
                                case 79:
                                case 83:
                                case 89:
                                case 97:
                                    Console.WriteLine($"{i}{j}");
                                    break;
                            }

                            break;
                    }
                }
            }
        }
    }
}
