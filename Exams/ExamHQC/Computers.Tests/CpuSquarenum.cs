namespace Computers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.CPUs;
    using Moq;

    [TestClass]
    public class CpuSquarenum
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockedMother = new Mock<IMotherboard>();
            Cpu processor = new Cpu128(2);
            string result = string.Empty;
            mockedMother.Setup(x => x.DrawOnVideoCard(It.IsAny<string>())).Callback<string>(txt => result = txt);
            mockedMother.Setup(x => x.LoadRamValue()).Returns(2000);
            processor.AttachTo(mockedMother.Object);
            processor.SquareNumber();
            Assert.IsTrue(result.Contains("4000000"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var mockedMother = new Mock<IMotherboard>();
            Cpu processor = new Cpu128(2);
            string result = string.Empty;
            mockedMother.Setup(x => x.DrawOnVideoCard(It.IsAny<string>())).Callback<string>(txt => result = txt);
            mockedMother.Setup(x => x.LoadRamValue()).Returns(2001);
            processor.AttachTo(mockedMother.Object);
            processor.SquareNumber();
            Assert.AreEqual(processor.MessageForHighNumber, result);
        }

        [TestMethod]
        public void TestMethod22()
        {
            var mockedMother = new Mock<IMotherboard>();
            Cpu processor = new Cpu128(2);
            string result = string.Empty;
            mockedMother.Setup(x => x.DrawOnVideoCard(It.IsAny<string>())).Callback<string>(txt => result = txt);
            mockedMother.Setup(x => x.LoadRamValue()).Returns(-1);
            processor.AttachTo(mockedMother.Object);
            processor.SquareNumber();
            Assert.AreEqual(processor.MessageForLowNumber, result);
        }

        [TestMethod]
        public void TestMethod222()
        {
            var mockedMother = new Mock<IMotherboard>();
            Cpu processor = new Cpu128(2);
            string result = string.Empty;
            mockedMother.Setup(x => x.DrawOnVideoCard(It.IsAny<string>())).Callback<string>(txt => result = txt);
            mockedMother.Setup(x => x.LoadRamValue()).Returns(0);
            processor.AttachTo(mockedMother.Object);
            processor.SquareNumber();
            Assert.AreEqual(true, result.Contains("0"));
        }
    }
}
