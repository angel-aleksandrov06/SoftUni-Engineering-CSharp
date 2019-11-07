﻿namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaulFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption => defaulFuelConsumption;

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            var canDrive = this.Fuel - kilometers * FuelConsumption >= 0;
            if (canDrive)
            {
                this.Fuel -= (kilometers * FuelConsumption);
            }
        }
    }
}
