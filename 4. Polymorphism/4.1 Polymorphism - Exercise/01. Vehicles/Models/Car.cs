using System;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Car : IDriveable
    {
        public Car(double fuelQuantity, double consumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = consumption + 0.9;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKm;

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine($"Car needs refueling");
            }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void Refuel(double quantity)
        {
            FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}