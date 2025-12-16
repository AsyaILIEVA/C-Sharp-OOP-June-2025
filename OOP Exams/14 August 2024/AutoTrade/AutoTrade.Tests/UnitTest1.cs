using NUnit.Framework;
using AutoTrade;
using System;

namespace AutoTrade.Tests
{
    public class DealerShopTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            DealerShop shop = new DealerShop(5);

            Assert.That(shop.Capacity, Is.EqualTo(5));
            Assert.That(shop.Vehicles, Has.Count.EqualTo(0));
        }


        [Test]
        public void CapacityShouldThrowWhenZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DealerShop shop = new(0);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                DealerShop shop = new(-3);
            });
        }


        [Test]
        public void AddVehicleShouldAddVehicle()
        {
            DealerShop shop = new(2);
            Vehicle vehicle = new("BMW", "X5", 2020);

            string result = shop.AddVehicle(vehicle);

            Assert.That(shop.Vehicles.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo("Added 2020 BMW X5"));
        }


        [Test]
        public void AddVehicleShouldThrowWhenInventoryFull()
        {
            DealerShop shop = new(1);
            Vehicle vehicle1 = new("Audi", "A4", 2018);
            Vehicle vehicle2 = new("Honda", "Civic", 2022);

            shop.AddVehicle(vehicle1);

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.AddVehicle(vehicle2);
            });

            Assert.That(ex.Message, Is.EqualTo("Inventory is full"));
        }


        [Test]
        public void SellVehicleShouldReturnTrueWhenVehicleExists()
        {
            DealerShop shop = new DealerShop(2);
            Vehicle vehicle = new Vehicle("Toyota", "Corolla", 2019);

            shop.AddVehicle(vehicle);
            bool result = shop.SellVehicle(vehicle);

            Assert.That(result, Is.True);
            Assert.That(shop.Vehicles, Has.Count.EqualTo(0));
        }


        [Test]
        public void SellVehicleShouldReturnFalseWhenVehicleNotFound()
        {
            DealerShop shop = new(2);
            Vehicle v1 = new("Ford", "Focus", 2015);
            Vehicle v2 = new("Kia", "Rio", 2017);

            shop.AddVehicle(v1);

            bool result = shop.SellVehicle(v2);

            Assert.That(result, Is.False);
        }
    }
}