//using NUnit.Framework;
//using System;


//namespace SmartphoneShop.Tests
//{
//    [TestFixture]
//    public class SmartphoneShopTests
//    {
//        private const string DEF_PHONE_MODEL = "Test model";
//        private const int DEF_PHONE_MAX_CHARGE = 100;
//        private const int DEF_SHOP_CAPACITY = 2;

//        private Smartphone phone;
//        private Shop shop;

//        [SetUp]
//        public void Setup()
//        {
//            phone = new Smartphone(DEF_PHONE_MODEL, DEF_PHONE_MAX_CHARGE);
//            shop = new Shop(DEF_SHOP_CAPACITY);
//        }

//        [Test]
//        public void Phone_Constructor_CreatesObjectProperly()
//        {
//            int expectedCurrentCharge = DEF_PHONE_MAX_CHARGE;
//            Assert.True(phone.ModelName == DEF_PHONE_MODEL &&
//                        phone.MaximumBatteryCharge == DEF_PHONE_MAX_CHARGE &&
//                        phone.CurrentBateryCharge == expectedCurrentCharge);
//        }

//        [Test]
//        public void Shop_Constructor_CreatesObjectProperly()
//        {
//            Assert.True(shop.Capacity == DEF_SHOP_CAPACITY);
//        }

//        [Test]
//        public void Shop_PropertyCapacity_ThrowsForNegativeValue()
//        {
//            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
//        }

//        [Test]
//        public void Shop_Add_IncreasesCount()
//        {
//            shop.Add(phone);
//            Assert.AreEqual(shop.Count, 1);
//        }

//        [Test]
//        public void Shop_Add_ThrowsForExistingPhone()
//        {
//            shop.Add(phone);
//            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone(DEF_PHONE_MODEL, 0)));
//        }

//        [Test]
//        public void Shop_Add_ThrowsForFullCapacity()
//        {
//            Smartphone phone2 = new Smartphone("Token phone 1", DEF_PHONE_MAX_CHARGE);
//            Smartphone phone3 = new Smartphone("Token phone 2", DEF_PHONE_MAX_CHARGE);
//            shop.Add(phone);
//            shop.Add(phone2);
//            Assert.Throws<InvalidOperationException>(() => shop.Add(phone3));
//        }

//        [Test]
//        public void Shop_Remove_DecreasesCount()
//        {
//            shop.Add(phone);
//            shop.Remove(phone.ModelName);
//            Assert.AreEqual(shop.Count, 0);
//        }

//        [Test]
//        public void Shop_Remove_ThrowsForNonExistentPhone()
//        {
//            Assert.Throws<InvalidOperationException>(() => shop.Remove("Fake phone model"));
//        }

//        [Test]
//        public void Shop_TestPhone_DecreasesBatteryChargeProperly()
//        {
//            int testUsage = 40;
//            int expectedCharge = DEF_PHONE_MAX_CHARGE - testUsage;
//            shop.Add(phone);
//            shop.TestPhone(DEF_PHONE_MODEL, testUsage);
//            Assert.AreEqual(phone.CurrentBateryCharge, expectedCharge);
//        }

//        [Test]
//        public void Shop_TestPhone_ThrowsForNonExistentModel()
//        {
//            shop.Add(phone);
//            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Missing model", 40));
//        }

//        [Test]
//        public void Shop_TestPhone_ThrowsForLowBattery()
//        {
//            shop.Add(phone);
//            int testUsage = DEF_PHONE_MAX_CHARGE + 10;
//            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(DEF_PHONE_MODEL, testUsage));
//        }

//        [Test]
//        public void Shop_ChargePhone_RefillsBatteryChargeToMaximum()
//        {
//            int testUsage = 20;
//            shop.Add(phone);
//            shop.TestPhone(DEF_PHONE_MODEL, testUsage);
//            shop.ChargePhone(DEF_PHONE_MODEL);
//            Assert.AreEqual(phone.CurrentBateryCharge, DEF_PHONE_MAX_CHARGE);
//        }

//        [Test]
//        public void Shop_ChargePhone_ThrowsForNonExistentModel()
//        {
//            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Missing model"));
//        }

//    }
//}
using NUnit.Framework;
using SmartphoneShop;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class ShopTests
    {
        // ---------- Constructor & Capacity ----------

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Shop shop = new Shop(5);

            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Capacity_ShouldThrow_WhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            });
        }

        // ---------- Add() Tests ----------

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("Samsung", 100);

            shop.Add(phone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Add_ShouldThrow_WhenModelAlreadyExists()
        {
            Shop shop = new Shop(2);
            Smartphone phone1 = new Smartphone("iPhone", 100);
            Smartphone phone2 = new Smartphone("iPhone", 200);

            shop.Add(phone1);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.Add(phone2));
            Assert.AreEqual("The phone model iPhone already exist.", ex.Message);
        }

        [Test]
        public void Add_ShouldThrow_WhenShopIsFull()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Nokia", 100);
            Smartphone phone2 = new Smartphone("Sony", 100);

            shop.Add(phone1);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.Add(phone2));
            Assert.AreEqual("The shop is full.", ex.Message);
        }

        // ---------- Remove() Tests ----------

        [Test]
        public void Remove_ShouldRemovePhone()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("HTC", 100);

            shop.Add(phone);
            shop.Remove("HTC");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Remove_ShouldThrow_WhenModelDoesNotExist()
        {
            Shop shop = new Shop(2);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.Remove("Missing"));

            Assert.AreEqual("The phone model Missing doesn't exist.", ex.Message);
        }

        // ---------- TestPhone() Tests ----------

        [Test]
        public void TestPhone_ShouldReduceBattery()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("Xiaomi", 100);

            shop.Add(phone);
            shop.TestPhone("Xiaomi", 30);

            Assert.AreEqual(70, phone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhone_ShouldThrow_WhenPhoneMissing()
        {
            Shop shop = new Shop(1);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("None", 10));

            Assert.AreEqual("The phone model None doesn't exist.", ex.Message);
        }

        [Test]
        public void TestPhone_ShouldThrow_WhenBatteryTooLow()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("Pixel", 20);

            shop.Add(phone);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Pixel", 50));

            Assert.AreEqual("The phone model Pixel is low on batery.", ex.Message);
        }

        // ---------- ChargePhone() Tests ----------

        [Test]
        public void ChargePhone_ShouldRestoreBattery()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("Motorola", 100);
            shop.Add(phone);

            // drain battery
            shop.TestPhone("Motorola", 40);

            // recharge
            shop.ChargePhone("Motorola");

            Assert.AreEqual(100, phone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhone_ShouldThrow_WhenPhoneMissing()
        {
            Shop shop = new Shop(1);

            var ex = Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Unknown"));

            Assert.AreEqual("The phone model Unknown doesn't exist.", ex.Message);
        }
    }
}
