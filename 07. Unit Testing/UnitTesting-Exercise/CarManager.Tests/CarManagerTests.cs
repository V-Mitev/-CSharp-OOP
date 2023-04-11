namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Mercedes-Benz", "C220", 9.5, 65);
        }

        [TearDown] public void TearDown()
        {
            car = null;
        }

        [Test]
        public void CreateCar()
        {
            car = new Car("Mercedes-Benz", "C220", 9.5, 65);

            Assert.AreEqual("Mercedes-Benz", car.Make);
            Assert.AreEqual("C220", car.Model);
            Assert.AreEqual(9.5, car.FuelConsumption);
            Assert.AreEqual(65, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateCarFailsIfMakeIsNullOrEmpty(string make)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, "C220", 9.5, 65);
            });

            Assert.That(ae.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateCarFailsIfModelIsNullOrEmpty(string model)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mercedes", model, 9.5, 65);
            });

            Assert.That(ae.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void CreateCarFailsIfFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mercedes-Benz", "C220", fuelConsumption, 65);
            });

            Assert.That(ae.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void CreateCarFailsWithFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mercedes-Benz","C220",9.5,fuelCapacity);
            });

            Assert.That(ae.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void RefuelShouldThrowIfZeroOrNegative(double litters)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(litters);
            });

            Assert.That(ae.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelShouldBeEqualToFuelCapacity()
        {
            car.Refuel(69);

            Assert.AreEqual(65, car.FuelAmount);
        }

        [Test]
        public void RefuelShouldBeEqualToFuelAmount()
        {
            car.Refuel(15);

            Assert.AreEqual(15, car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowIfCapacityIsNotEnough()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1);
            });

            Assert.That(ioe.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveShouldLeaveFuel()
        {
            car.Refuel(10);
            car.Drive(100); 

            Assert.AreEqual(0.5, car.FuelAmount);
        }
    }
}