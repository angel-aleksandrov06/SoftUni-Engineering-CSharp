using System;
using System.Text;

namespace _1.Rhombus_of_Stars
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var stringBuilder = new StringBuilder();

            for (int i = 1; i < size; i++)
            {
                stringBuilder.Append(new string(' ', size - i));
                DrawLineOfStars(stringBuilder, i);

            }
            DrawLineOfStars(stringBuilder, size);

            for (int i = size - 1; i >= 1; i--)
            {
                stringBuilder.Append(new string(' ', size - i));
                DrawLineOfStars(stringBuilder, i);
            }

            Console.WriteLine(stringBuilder);
        }

        public static void DrawLineOfStars(StringBuilder stringBuilder, int numbersOfStars)
        {
            for (int star = 0; star < numbersOfStars; star++)
            {
                stringBuilder.Append('*');
                if (star < numbersOfStars - 1)
                {
                    stringBuilder.Append(' ');
                }
            }
            stringBuilder.AppendLine();
        }
    }
}
