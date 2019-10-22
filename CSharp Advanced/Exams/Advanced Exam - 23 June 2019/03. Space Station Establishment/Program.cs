using System;

namespace _03._Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfGalaxy = int.Parse(Console.ReadLine());
            var galaxy = new char[sizeOfGalaxy, sizeOfGalaxy];

            var rowOfStephan = 0;
            var colOfStephan = 0;
            var stephanPower = 0;

            var isOutOfGalaxy = false;

            for (int i = 0; i < sizeOfGalaxy; i++)
            {
                var charArray = Console.ReadLine().ToCharArray();

                for (int j = 0; j < sizeOfGalaxy; j++)
                {
                    if (charArray[j] == 'S')
                    {
                        rowOfStephan = i;
                        colOfStephan = j;
                    }

                    galaxy[i, j] = charArray[j];
                }
            }

            while (true)
            {
                if (stephanPower >= 50)
                {
                    break;
                }
                var command = Console.ReadLine();

                if (command == "up")
                {
                    rowOfStephan--;
                    var isStillPlaing = IsMatrixValid(rowOfStephan, colOfStephan, galaxy);

                    if (!isStillPlaing)
                    {
                        galaxy[rowOfStephan + 1, colOfStephan] = '-';
                        isOutOfGalaxy = true;
                        break;
                    }
                    else
                    {
                        if (char.IsDigit(galaxy[rowOfStephan, colOfStephan]))
                        {
                            stephanPower += int.Parse(galaxy[rowOfStephan, colOfStephan].ToString());
                            galaxy[rowOfStephan + 1, colOfStephan] = '-';
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == 'O')
                        {
                            galaxy[rowOfStephan, colOfStephan] = '-';
                            galaxy[rowOfStephan + 1, colOfStephan] = '-';

                            for (int i = 0; i < galaxy.GetLength(0); i++)
                            {
                                for (int j = 0; j < galaxy.GetLength(1); j++)
                                {
                                    if (galaxy[i, j] == 'O')
                                    {
                                        rowOfStephan = i;
                                        colOfStephan = j;
                                    }

                                }
                            }
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == '-')
                        {
                            galaxy[rowOfStephan + 1, colOfStephan] = '-';
                        }
                        galaxy[rowOfStephan, colOfStephan] = 'S';
                    }
                }
                else if (command == "down")
                {
                    rowOfStephan++;
                    var isStillPlaing = IsMatrixValid(rowOfStephan, colOfStephan, galaxy);
                    if (!isStillPlaing)
                    {
                        galaxy[rowOfStephan - 1, colOfStephan] = '-';
                        isOutOfGalaxy = true;
                        break;
                    }
                    else
                    {
                        if (char.IsDigit(galaxy[rowOfStephan, colOfStephan]))
                        {
                            stephanPower += int.Parse(galaxy[rowOfStephan, colOfStephan].ToString());
                            galaxy[rowOfStephan - 1, colOfStephan] = '-';
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == 'O')
                        {
                            galaxy[rowOfStephan, colOfStephan] = '-';
                            galaxy[rowOfStephan - 1, colOfStephan] = '-';

                            for (int i = 0; i < galaxy.GetLength(0); i++)
                            {
                                for (int j = 0; j < galaxy.GetLength(1); j++)
                                {
                                    if (galaxy[i, j] == 'O')
                                    {
                                        rowOfStephan = i;
                                        colOfStephan = j;
                                    }

                                }
                            }
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == '-')
                        {
                            galaxy[rowOfStephan - 1, colOfStephan] = '-';
                        }
                        galaxy[rowOfStephan, colOfStephan] = 'S';
                    }
                }
                else if (command == "left")
                {
                    colOfStephan--;
                    var isStillPlaing = IsMatrixValid(rowOfStephan, colOfStephan, galaxy);
                    if (!isStillPlaing)
                    {
                        galaxy[rowOfStephan, colOfStephan + 1] = '-';
                        isOutOfGalaxy = true;
                        break;
                    }
                    else
                    {
                        if (char.IsDigit(galaxy[rowOfStephan, colOfStephan]))
                        {
                            stephanPower += int.Parse(galaxy[rowOfStephan, colOfStephan].ToString());
                            galaxy[rowOfStephan, colOfStephan + 1] = '-';
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == 'O')
                        {
                            galaxy[rowOfStephan, colOfStephan] = '-';
                            galaxy[rowOfStephan, colOfStephan + 1] = '-';

                            for (int i = 0; i < galaxy.GetLength(0); i++)
                            {
                                for (int j = 0; j < galaxy.GetLength(1); j++)
                                {
                                    if (galaxy[i, j] == 'O')
                                    {
                                        rowOfStephan = i;
                                        colOfStephan = j;
                                    }

                                }
                            }
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == '-')
                        {
                            galaxy[rowOfStephan, colOfStephan + 1] = '-';
                        }
                        galaxy[rowOfStephan, colOfStephan] = 'S';
                    }
                }
                else if (command == "right")
                {
                    colOfStephan++;
                    var isStillPlaing = IsMatrixValid(rowOfStephan, colOfStephan, galaxy);
                    if (!isStillPlaing)
                    {
                        galaxy[rowOfStephan, colOfStephan - 1] = '-';
                        isOutOfGalaxy = true;
                        break;
                    }
                    else
                    {
                        if (char.IsDigit(galaxy[rowOfStephan, colOfStephan]))
                        {
                            stephanPower += int.Parse(galaxy[rowOfStephan, colOfStephan].ToString());
                            galaxy[rowOfStephan, colOfStephan - 1] = '-';
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == 'O')
                        {
                            galaxy[rowOfStephan, colOfStephan] = '-';
                            galaxy[rowOfStephan, colOfStephan - 1] = '-';

                            for (int i = 0; i < galaxy.GetLength(0); i++)
                            {
                                for (int j = 0; j < galaxy.GetLength(1); j++)
                                {
                                    if (galaxy[i, j] == 'O')
                                    {
                                        rowOfStephan = i;
                                        colOfStephan = j;
                                    }

                                }
                            }
                        }
                        else if (galaxy[rowOfStephan, colOfStephan] == '-')
                        {
                            galaxy[rowOfStephan, colOfStephan - 1] = '-';
                        }
                        galaxy[rowOfStephan, colOfStephan] = 'S';
                    }
                }
            }

            Print(galaxy, stephanPower, isOutOfGalaxy);
        }

        private static void Print(char[,] galaxy, int stephanPower, bool isOutOfGalaxy)
        {
            if (isOutOfGalaxy)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {stephanPower}");
            for (int i = 0; i < galaxy.GetLength(0); i++)
            {
                for (int j = 0; j < galaxy.GetLength(1); j++)
                {
                    Console.Write(galaxy[i, j]);
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
