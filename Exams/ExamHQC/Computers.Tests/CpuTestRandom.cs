namespace Computers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.CPUs;
    using Moq;

    [TestClass]
    public class CpuTestRandom
    {
        [TestMethod]
        public void TestRandomToHaveMinimalValue()
        {
            var mockedMother = new Mock<IMotherboard>();
            int value = int.MaxValue;

            mockedMother.Setup(x => x.SaveRamValue(It.IsAny<int>())).Callback<int>(calcNum => value = Math.Min(value, calcNum));
            
            Cpu processor = new Cpu128(2);
            processor.AttachTo(mockedMother.Object);
            int expectedResult = 1;
            for (int i = 0; i < 1000; i++)
            {
                processor.Rand(1, 10);
            }

            Assert.AreEqual(expectedResult, value);
        }

        [TestMethod]
        public void TestRandomToHaveMaximalValue()
        {
            var mockedMother = new Mock<IMotherboard>();
            int value = int.MinValue;

            mockedMother.Setup(x => x.SaveRamValue(It.IsAny<int>())).Callback<int>(calcNum => value = Math.Max(value, calcNum));

            Cpu processor = new Cpu128(2);
            processor.AttachTo(mockedMother.Object);
            int expectedResult = 10;
            for (int i = 0; i < 1000; i++)
            {
                processor.Rand(1, 10);
            }

            Assert.AreEqual(expectedResult, value);
        }
    }
}
