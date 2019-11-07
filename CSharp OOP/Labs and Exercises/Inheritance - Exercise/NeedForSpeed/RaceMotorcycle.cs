﻿namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaulFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => defaulFuelConsumption;
    }
}
