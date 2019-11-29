namespace _01Vehicles.Model
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }

        public bool Drive(double distance)
        {
            bool canDrive = this.FuelQuantity - this.FuelConsumption * distance >= 0;
            if (canDrive)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;

                return true;
            }

            // throw new InvalidOperationException();

            return false;
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
