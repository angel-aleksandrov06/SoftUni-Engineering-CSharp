using System;
using System.Linq;

namespace Point_in_Rectangle
{
    public class StartUp
    {
        public static void Main()
        {
            var rangeOfREgtangle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var topLeftX = rangeOfREgtangle[0];
            var topLeftY = rangeOfREgtangle[1];
            var bottomRightX = rangeOfREgtangle[2];
            var bottomRightY = rangeOfREgtangle[3];

            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            var inputCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCounts; i++)
            {
                var inputCurretPoint = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var inputX = inputCurretPoint[0];
                var inputY = inputCurretPoint[1];

                var currentPoint = new Point(inputX, inputY);

                var isInRange = rectangle.Contains(currentPoint);
                Console.WriteLine(isInRange);
            }
        }
    }
}
