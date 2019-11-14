namespace _03Ferrari
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            IFerrari car = new Ferrari(driver);

            Console.WriteLine($"{car.Model}/{car.UseBrakes()}/{car.PushTheGasPedal()}/{car.Driver}");
        }
    }
}
