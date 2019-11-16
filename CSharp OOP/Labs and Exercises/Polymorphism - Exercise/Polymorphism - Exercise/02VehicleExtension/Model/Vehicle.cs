namespace _02VehicleExtension.Model
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            private set
            {
                if (value > this.tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            private set
            {
                tankCapacity = value;
            }
        }

        public virtual bool Drive(double distance)
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
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            this.FuelQuantity += fuel;
        }
    }
}
