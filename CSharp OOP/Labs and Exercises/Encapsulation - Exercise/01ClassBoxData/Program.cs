using System;

namespace _01ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetBoxSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetBoxLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetBoxVolume():F2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
