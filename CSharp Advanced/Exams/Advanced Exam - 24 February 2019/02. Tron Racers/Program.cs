using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            var field = new char[sizeMatrix,sizeMatrix];

            var rowF = 0;
            var colF = 0;
            var rowS = 0;
            var colS = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                var input = Console.ReadLine().Replace(" ", "");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (input[j] == 'f')
                    {
                        rowF = i;
                        colF = j;
                    }
                    else if (input[j] == 's')
                    {
                        rowS = i;
                        colS = j;
                    }
                    field[i, j] = input[j];
                }
            }

            while (true)
            {
                var commandParts = Console.ReadLine().Split();

                var fCommand = commandParts[0];
                var sCommand = commandParts[1];

                if (fCommand == "up")
                {
                    rowF--;
                    var isMatrixValid = IsMatrixValid(rowF, colF, field);
                    if (isMatrixValid)
                    {
                        if (field[rowF,colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        rowF += sizeMatrix;
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                }
                else if (fCommand == "down")
                {
                    rowF++;
                    var isMatrixValid = IsMatrixValid(rowF, colF, field);
                    if (isMatrixValid)
                    {
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        rowF -= sizeMatrix;
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                }
                else if (fCommand == "left")
                {
                    colF--;
                    var isMatrixValid = IsMatrixValid(rowF, colF, field);
                    if (isMatrixValid)
                    {
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        colF += sizeMatrix;
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                }
                else if (fCommand == "right")
                {
                    colF++;
                    var isMatrixValid = IsMatrixValid(rowF, colF, field);
                    if (isMatrixValid)
                    {
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        colF -= sizeMatrix;
                        if (field[rowF, colF] == '*')
                        {
                            field[rowF, colF] = 'f';
                        }
                        else if (field[rowF, colF] == 's')
                        {
                            field[rowF, colF] = 'x';
                            break;
                        }
                    }
                }

                if (sCommand == "up")
                {
                    rowS--;
                    var isMatrixValid = IsMatrixValid(rowS, colS, field);
                    if (isMatrixValid)
                    {
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        rowS += sizeMatrix;
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                }
                else if (sCommand == "down")
                {
                    rowS++;
                    var isMatrixValid = IsMatrixValid(rowS, colS, field);
                    if (isMatrixValid)
                    {
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        rowS -= sizeMatrix;
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                }
                else if (sCommand == "left")
                {
                    colS--;
                    var isMatrixValid = IsMatrixValid(rowS, colS, field);
                    if (isMatrixValid)
                    {
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        colS += sizeMatrix;
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                }
                else if (sCommand == "right")
                {
                    colS++;
                    var isMatrixValid = IsMatrixValid(rowS, colS, field);
                    if (isMatrixValid)
                    {
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        colS -= sizeMatrix;
                        if (field[rowS, colS] == '*')
                        {
                            field[rowS, colS] = 's';
                        }
                        else if (field[rowS, colS] == 'f')
                        {
                            field[rowS, colS] = 'x';
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]);
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
