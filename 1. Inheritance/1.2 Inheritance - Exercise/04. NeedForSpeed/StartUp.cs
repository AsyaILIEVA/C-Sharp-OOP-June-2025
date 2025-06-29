using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar car = new(150, 100);
            car.Drive(10);
            Console.WriteLine(car.Fuel);
        }
    }
}
