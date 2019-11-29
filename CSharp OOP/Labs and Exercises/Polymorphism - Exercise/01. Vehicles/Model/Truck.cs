namespace _01Vehicles.Model
{
    public class Truck : Vehicle
    {
        private const double AirConditionAddtionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditionAddtionConsumption;
        }

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            base.Refuel(fuel);
        }
    }
}
