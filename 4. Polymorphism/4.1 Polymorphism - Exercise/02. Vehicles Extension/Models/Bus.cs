using System;
using Vehicles.Interfaces;

namespace Vehicles
{
    public class Bus : IDriveable
    {
        public Bus(double fuelQuantity, double consumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
            FuelConsumptionPerKm = consumption + 1.4;
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
                Console.WriteLine($"Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void DriveEmpty(double distance)
        {
            FuelConsumptionPerKm -= 1.4;
            Drive(distance);
        }

        public void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (FuelQuantity + quantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                return;
            }

            FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}