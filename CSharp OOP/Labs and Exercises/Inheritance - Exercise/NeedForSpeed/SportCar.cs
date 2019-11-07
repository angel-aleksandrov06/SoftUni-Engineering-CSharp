namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaulFuelConsumption = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => defaulFuelConsumption;
    }
}
