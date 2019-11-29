namespace _02VehicleExtension.Model
{
    public class Bus : Vehicle
    {
        private double airConditionAddtionConsumption = 1.4;
        private double defaultFuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.defaultFuelConsumption = fuelConsumption;
            this.airConditionAddtionConsumption += fuelConsumption;
        }

        public bool IsEmpty { get; set; }

        public override bool Drive(double distance)
        {
            if (!this.IsEmpty)
            {
                this.FuelConsumption = this.airConditionAddtionConsumption;
            }
            else
            {
                this.FuelConsumption = this.defaultFuelConsumption;
            }

            return base.Drive(distance);
        }
    }
}
