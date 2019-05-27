using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTournirs = int.Parse(Console.ReadLine());
            int startCountPoints = int.Parse(Console.ReadLine());
            int points = startCountPoints;
            int countWins = 0;

            for (int i = 1; i <= countTournirs; i++)
            {
                int segashniTochki = 0;

                string etap = Console.ReadLine();
                switch (etap)
                {
                    case "W":
                        segashniTochki = 2000;
                        countWins++;
                        break;
                    case "F":
                        segashniTochki = 1200;
                        break;
                    case "SF":
                        segashniTochki = 720;
                        break;
                    default:
                        break;
                }
                points += segashniTochki;
                

            }
            double averagePointOfTournir = Math.Floor((points - startCountPoints)*1.0 / countTournirs);
            double PercentWins = (countWins*1.0 / countTournirs*1.0) * 100;

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {averagePointOfTournir}");
            Console.WriteLine($"{PercentWins:F2}%");
        }
    }
}
