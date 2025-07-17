using System;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Truck : IDriveable
    {
        public Truck(double fuelQuantity, double consumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
            FuelConsumptionPerKm = consumption + 1.6;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public double TankCapacity { get; private set; }

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

        public void DriveEmpty(double distance)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (FuelQuantity + quantity * 0.95 > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                return;
            }
            FuelQuantity += quantity * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}