using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance;

        public Car(string model, double fuelAmount, double fuelComsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelComsumption;
        }

        public string Model { get => model; set => model = value; }
        public double FuelAmount { get => fuelAmount; set => fuelAmount = value; }

        public double FuelConsumptionPerKilometer { get => fuelConsumptionPerKilometer; set => fuelConsumptionPerKilometer = value; }

        public double TraveledDistace { get => traveledDistance; set => traveledDistance = value; }


        public bool MoveTheCar(int distance)
        {
            if (distance * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= FuelConsumptionPerKilometer * distance;
                TraveledDistace += distance;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TraveledDistace}";
        }
    }
}
