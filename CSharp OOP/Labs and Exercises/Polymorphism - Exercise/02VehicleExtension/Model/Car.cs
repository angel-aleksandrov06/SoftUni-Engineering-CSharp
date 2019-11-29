namespace _02VehicleExtension.Model
{
    public class Car : Vehicle
    {
        private const double AirConditionAddtionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditionAddtionConsumption;
        }
    }
}
