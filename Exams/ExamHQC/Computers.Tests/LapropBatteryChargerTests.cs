namespace Computers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class LapropBatteryChargerTests
    {
        [TestMethod]
        public void Initial()
        {
            LaptopBattery b = new LaptopBattery();
            Assert.AreEqual(50, b.Percentage);
        }

        [TestMethod]
        public void Method2()
        {
            LaptopBattery b = new LaptopBattery();
            b.Charge(2000);
            Assert.AreEqual(100, b.Percentage);
        }

        [TestMethod]
        public void Method3()
        {
            LaptopBattery b = new LaptopBattery();
            b.Charge(-2000);
            Assert.AreEqual(00, b.Percentage);
        }

        [TestMethod]
        public void Method4()
        {
            LaptopBattery b = new LaptopBattery();
            b.Charge(0);
            Assert.AreEqual(50, b.Percentage);
        }
    }
}
