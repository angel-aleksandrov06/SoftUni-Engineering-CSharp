using System;
using System.Linq;

namespace _02._Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());

            var field = new char[rows][];
            var parisRow = 0;
            var parisCol = 0;
            var isParisWin = false;

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                field[i] = input;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'P')
                    {
                        parisRow = i;
                        parisCol = j;
                        break;

                    }
                }
            }

            while (true)
            {
                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    break;
                }
                var commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var direction = commandParts[0];
                var spawnRow = int.Parse(commandParts[1]);
                var spawnCol = int.Parse(commandParts[2]);

                field[spawnRow][spawnCol] = 'S';

                if (direction == "up")
                {
                    energy--;
                    var isIndexValid = IsIndexValid(parisRow-1, parisCol, field);
                    if (isIndexValid)
                    {
                        parisRow--;
                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy-=2;

                            field[parisRow][parisCol] = 'P';
                            field[parisRow+1][parisCol] = '-';

                        }
                        else if (field[parisRow][parisCol] == 'H')
                        {
                            field[parisRow][parisCol] = '-';
                            field[parisRow+1][parisCol] = '-';
                            isParisWin = true;
                            break;
                        }
                        else
                        {
                            field[parisRow][parisCol] = 'P';
                            field[parisRow+1][parisCol] = '-';
                        }
                    }
                }
                else if (direction == "down")
                {
                    energy--;
                    var isIndexValid = IsIndexValid(parisRow+1, parisCol, field);
                    if (isIndexValid)
                    {
                        parisRow++;
                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            field[parisRow][parisCol] = 'P';
                            field[parisRow-1][parisCol] = '-';

                        }
                        else if (field[parisRow][parisCol] == 'H')
                        {
                            field[parisRow][parisCol] = '-';
                            field[parisRow-1][parisCol] = '-';
                            isParisWin = true;
                            break;
                        }
                        else
                        {
                            field[parisRow][parisCol] = 'P';
                            field[parisRow - 1][parisCol] = '-';
                        }
                    }
                }
                else if (direction == "left")
                {
                    energy--;
                    var isIndexValid = IsIndexValid(parisRow, parisCol-1, field);
                    if (isIndexValid)
                    {
                        parisCol--;
                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            field[parisRow][parisCol] = 'P';
                            field[parisRow][parisCol+1] = '-';

                        }
                        else if (field[parisRow][parisCol] == 'H')
                        {
                            field[parisRow][parisCol] = '-';
                            field[parisRow][parisCol+1] = '-';
                            isParisWin = true;
                            break;
                        }
                        else
                        {
                            field[parisRow][parisCol] = 'P';
                            field[parisRow][parisCol+1] = '-';
                        }
                    }
                }
                else if (direction == "right")
                {
                    energy--;
                    var isIndexValid = IsIndexValid(parisRow, parisCol+1, field);
                    if (isIndexValid)
                    {
                        parisCol++;
                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;

                            field[parisRow][parisCol] = 'P';
                            field[parisRow][parisCol-1] = '-';

                        }
                        else if (field[parisRow][parisCol] == 'H')
                        {
                            field[parisRow][parisCol] = '-';
                            field[parisRow][parisCol-1] = '-';
                            isParisWin = true;
                            break;
                        }
                        else
                        {
                            field[parisRow][parisCol] = 'P';
                            field[parisRow][parisCol-1] = '-';
                        }
                    }
                }
            }

            if (isParisWin)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", field[i]));
            }

        }
        public static bool IsIndexValid(int row, int col, char[][] matrix) =>
            (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length) ? true : false;
    }
}
