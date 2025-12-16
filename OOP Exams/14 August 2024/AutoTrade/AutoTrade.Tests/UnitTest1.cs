//using NUnit.Framework;
//using AutoTrade;
//using System;

//namespace AutoTrade.Tests
//{
//    public class DealerShopTests
//    {
//        [Test]
//        public void ConstructorShouldInitializeCorrectly()
//        {
//            DealerShop shop = new DealerShop(5);

//            Assert.That(shop.Capacity, Is.EqualTo(5));
//            Assert.That(shop.Vehicles, Has.Count.EqualTo(0));
//        }


//        [Test]
//        public void CapacityShouldThrowWhenZeroOrNegative()
//        {
//            Assert.Throws<ArgumentException>(() =>
//            {
//                DealerShop shop = new(0);
//            });

//            Assert.Throws<ArgumentException>(() =>
//            {
//                DealerShop shop = new(-3);
//            });
//        }


//        [Test]
//        public void AddVehicleShouldAddVehicle()
//        {
//            DealerShop shop = new(2);
//            Vehicle vehicle = new("BMW", "X5", 2020);

//            string result = shop.AddVehicle(vehicle);

//            Assert.That(shop.Vehicles.Count, Is.EqualTo(1));
//            Assert.That(result, Is.EqualTo("Added 2020 BMW X5"));
//        }


//        [Test]
//        public void AddVehicleShouldThrowWhenInventoryFull()
//        {
//            DealerShop shop = new(1);
//            Vehicle vehicle1 = new("Audi", "A4", 2018);
//            Vehicle vehicle2 = new("Honda", "Civic", 2022);

//            shop.AddVehicle(vehicle1);

//            var ex = Assert.Throws<InvalidOperationException>(() =>
//            {
//                shop.AddVehicle(vehicle2);
//            });

//            Assert.That(ex.Message, Is.EqualTo("Inventory is full"));
//        }


//        [Test]
//        public void SellVehicleShouldReturnTrueWhenVehicleExists()
//        {
//            DealerShop shop = new DealerShop(2);
//            Vehicle vehicle = new Vehicle("Toyota", "Corolla", 2019);

//            shop.AddVehicle(vehicle);
//            bool result = shop.SellVehicle(vehicle);

//            Assert.That(result, Is.True);
//            Assert.That(shop.Vehicles, Has.Count.EqualTo(0));
//        }


//        [Test]
//        public void SellVehicleShouldReturnFalseWhenVehicleNotFound()
//        {
//            DealerShop shop = new(2);
//            Vehicle v1 = new("Ford", "Focus", 2015);
//            Vehicle v2 = new("Kia", "Rio", 2017);

//            shop.AddVehicle(v1);

//            bool result = shop.SellVehicle(v2);

//            Assert.That(result, Is.False);
//        }
//    }
//}

using NUnit.Framework;
using AutoTrade;
using System;
using System.Linq;

namespace AutoTrade.Tests
{
    public class DealerShopTests
    {
        [Test]
        public void Constructor_ShouldInitializeWithValidCapacity()
        {
            DealerShop shop = new DealerShop(5);

            Assert.That(shop.Capacity, Is.EqualTo(5));
            Assert.That(shop.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenCapacityIsZero()
        {
            Assert.That(() => new DealerShop(0),
                Throws.ArgumentException);
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenCapacityIsNegative()
        {
            Assert.That(() => new DealerShop(-1),
                Throws.ArgumentException);
        }

        [Test]
        public void AddVehicle_ShouldAddVehicleSuccessfully()
        {
            DealerShop shop = new DealerShop(2);
            Vehicle vehicle = new Vehicle("BMW", "X5", 2020);

            string result = shop.AddVehicle(vehicle);

            Assert.That(shop.Vehicles.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo("Added 2020 BMW X5"));
            Assert.That(shop.Vehicles.Contains(vehicle), Is.True);
        }

        [Test]
        public void AddVehicle_ShouldThrowException_WhenInventoryIsFull()
        {
            DealerShop shop = new DealerShop(1);
            shop.AddVehicle(new Vehicle("Audi", "A4", 2019));

            Assert.That(() => shop.AddVehicle(new Vehicle("Mercedes", "C200", 2021)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void SellVehicle_ShouldReturnTrue_WhenVehicleExists()
        {
            DealerShop shop = new DealerShop(2);
            Vehicle vehicle = new Vehicle("Toyota", "Corolla", 2018);
            shop.AddVehicle(vehicle);

            bool result = shop.SellVehicle(vehicle);

            Assert.That(result, Is.True);
            Assert.That(shop.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellVehicle_ShouldReturnFalse_WhenVehicleDoesNotExist()
        {
            DealerShop shop = new DealerShop(2);
            Vehicle vehicle = new Vehicle("Honda", "Civic", 2017);

            bool result = shop.SellVehicle(vehicle);

            Assert.That(result, Is.False);
            Assert.That(shop.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void Vehicles_ShouldBeReadOnlyCollection()
        {
            DealerShop shop = new DealerShop(2);

            Assert.That(shop.Vehicles, Is.Not.InstanceOf<System.Collections.Generic.List<Vehicle>>());
        }

        [Test]
        public void InventoryReport_ShouldReturnCorrectReport_WhenNoVehicles()
        {
            DealerShop shop = new DealerShop(3);

            string report = shop.InventoryReport();

            string expected =
                "Inventory Report" + Environment.NewLine +
                "Capacity: 3" + Environment.NewLine +
                "Vehicles: 0";

            Assert.That(report, Is.EqualTo(expected));
        }

        [Test]
        public void InventoryReport_ShouldReturnCorrectReport_WithVehicles()
        {
            DealerShop shop = new DealerShop(3);
            Vehicle v1 = new Vehicle("Ford", "Focus", 2016);
            Vehicle v2 = new Vehicle("Mazda", "CX-5", 2022);

            shop.AddVehicle(v1);
            shop.AddVehicle(v2);

            string report = shop.InventoryReport();

            string expected =
                "Inventory Report" + Environment.NewLine +
                "Capacity: 3" + Environment.NewLine +
                "Vehicles: 2" + Environment.NewLine +
                "2016 Ford Focus" + Environment.NewLine +
                "2022 Mazda CX-5";

            Assert.That(report, Is.EqualTo(expected));
        }
    }
}
