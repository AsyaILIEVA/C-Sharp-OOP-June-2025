using System;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Truck : IDriveable
    {
        public Truck(double fuelQuantity, double consumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = consumption + 1.6;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKm;

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine($"Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void Refuel(double quantity)
        {
            FuelQuantity += quantity * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}