namespace _01Vehicles.Model
{
    public class Car : Vehicle
    {
        private const double AirConditionAddtionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditionAddtionConsumption;
        }
    }
}
