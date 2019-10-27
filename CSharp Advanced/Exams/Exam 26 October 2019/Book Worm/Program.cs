using System;
using System.Linq;
using System.Text;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var startsWord = Console.ReadLine();

            var sizeOfField = int.Parse(Console.ReadLine());
            var field = new char[sizeOfField, sizeOfField];

            var rowofPlayer = 0;
            var colofPlayer = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                var inputLine = Console.ReadLine();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = inputLine[j];
                    if (inputLine[j] == 'P')
                    {
                        rowofPlayer = i;
                        colofPlayer = j;
                    }
                }
            }

            var commmand = Console.ReadLine();

            while (commmand != "end")
            {

                if (commmand == "up")
                {
                    rowofPlayer--;

                    var isMatrixValid = IsMatrixValid(rowofPlayer, colofPlayer, field);

                    if (isMatrixValid)
                    {
                        if (char.IsLetter(field[rowofPlayer, colofPlayer]))
                        {
                            startsWord += field[rowofPlayer, colofPlayer];
                            field[rowofPlayer + 1, colofPlayer] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                        else
                        {
                            field[rowofPlayer + 1, colofPlayer] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                    }
                    else
                    {
                        rowofPlayer += 1;
                        if (startsWord.Length > 0)
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < startsWord.Length-1; i++)
                            {
                                sb.Append(startsWord[i]);
                            }

                            startsWord = sb.ToString();
                        }
                    }
                }
                else if (commmand == "down")
                {
                    rowofPlayer++;
                    var isMatrixValid = IsMatrixValid(rowofPlayer, colofPlayer, field);

                    if (isMatrixValid)
                    {
                        if (char.IsLetter(field[rowofPlayer, colofPlayer]))
                        {
                            startsWord += field[rowofPlayer, colofPlayer];
                            field[rowofPlayer - 1, colofPlayer] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                        else
                        {
                            field[rowofPlayer - 1, colofPlayer] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                    }
                    else
                    {
                        rowofPlayer -= 1;
                        if (startsWord.Length > 0)
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < startsWord.Length-1; i++)
                            {
                                sb.Append(startsWord[i]);
                            }

                            startsWord = sb.ToString();
                        }
                    }
                }
                else if (commmand == "left")
                {
                    colofPlayer--;
                    var isMatrixValid = IsMatrixValid(rowofPlayer, colofPlayer, field);

                    if (isMatrixValid)
                    {
                        if (char.IsLetter(field[rowofPlayer, colofPlayer]))
                        {
                            startsWord += field[rowofPlayer, colofPlayer];
                            field[rowofPlayer, colofPlayer + 1] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                        else
                        {
                            field[rowofPlayer, colofPlayer + 1] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                    }
                    else
                    {
                        colofPlayer += 1;
                        if (startsWord.Length > 0)
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < startsWord.Length-1; i++)
                            {
                                sb.Append(startsWord[i]);
                            }

                            startsWord = sb.ToString();
                        }
                    }
                }
                else if (commmand == "right")
                {
                    colofPlayer++;
                    var isMatrixValid = IsMatrixValid(rowofPlayer, colofPlayer, field);

                    if (isMatrixValid)
                    {
                        if (char.IsLetter(field[rowofPlayer, colofPlayer]))
                        {
                            startsWord += field[rowofPlayer, colofPlayer];
                            field[rowofPlayer, colofPlayer - 1] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                        else
                        {
                            field[rowofPlayer, colofPlayer - 1] = '-';
                            field[rowofPlayer, colofPlayer] = 'P';
                        }
                    }
                    else
                    {
                        colofPlayer -= 1;
                        if (startsWord.Length > 0)
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < startsWord.Length-1; i++)
                            {
                                sb.Append(startsWord[i]);
                            }

                            startsWord = sb.ToString();
                        }
                    }
                }

                commmand = Console.ReadLine();
            }

            Console.WriteLine(startsWord);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(string.Join("", field[i, j]));
                }
                Console.WriteLine();
            }

        }

        private static bool IsMatrixValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
