namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTesting
    {
        private readonly ICarsRepository fakeCarsData;
        private CarsController controller;

        public CarsControllerTesting()
            : this(new JustMockCarsRepo())
        {
        }

        private CarsControllerTesting(ICarsRepositoryMock mockCarsData)
        {
            this.fakeCarsData = mockCarsData.CarsData;
        }

        [TestInitialize]
        public void TestInitialization()
        {
            //// Just to pass through empty constructor.
            this.controller = new CarsController();
            this.controller = new CarsController(this.fakeCarsData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpectExceptionWhenIdIsNotInCarsData()
        {
            int theWrongID = 1120;
            this.controller.Details(theWrongID);
        }

        [TestMethod]
        public void ExpectToReturnTheOnlyOneCarFromFakedCarRepo()
        {
            var collection = (ICollection<Car>)this.GetModel(() => this.controller.Search("audi"));
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void ExpectToAddAllCarsInTheRepo()
        {
            int specialCount = 20;
            Car lenovoCar;

            for (int i = 0; i < specialCount; i++)
            {
                lenovoCar = new Car()
                {
                    Id = (i + 1) * 1000,
                    Make = "Lenovo",
                    Model = "L" + i.ToString(),
                    Year = DateTime.Now.Year
                };

                this.controller.Add(lenovoCar);
            }

            var collection = (ICollection<Car>)this.GetModel(() => this.controller.Search("Lenovo"));

            Assert.AreEqual(specialCount, collection.Count);
        }

        [TestMethod]
        public void ExpectedToReturnAEnpltyCollection()
        {
            var collection = (ICollection<Car>)this.GetModel(() => this.controller.Search(null));
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void ExpectRandomAddingCarsToReturnCorrectResults()
        {
            string[] carMakers = { "Most Wanted", "Brothers", "Big Brothers", "Most Computers", "Brothers arms", "YalWanted" };
            string[] carModels = { "A1", "B2", "A6", "Z1", "Z2", "E3", "L3", "L1" };
            int[] years = { 2000, 2003, 1999, 2005, 2001 };
            byte specialCounter = 100;
            Car randomizedCar;

            for (int i = 0; i < specialCounter; i++)
            {
                randomizedCar = new Car()
                {
                    Id = (i + 1) * 1000,
                    Make = carMakers[i % carMakers.Length],
                    Model = carModels[i % carModels.Length],
                    Year = years[i % years.Length]
                };

                this.controller.Add(randomizedCar);
            }

            var collectionOfCarsFromMakerContainsMost = (ICollection<Car>)this.GetModel(() => this.controller.Search("most"));
            var collectionOfCarsFromMakerContainsBrother = (ICollection<Car>)this.GetModel(() => this.controller.Search("brother"));
            var collectionOfCarsFromMakerContainsWanted = (ICollection<Car>)this.GetModel(() => this.controller.Search("wanted"));
            var collectionOfCarsModelContainsOne = (ICollection<Car>)this.GetModel(() => this.controller.Search("1"));
            var collectionOfCarsModelContainsSix = (ICollection<Car>)this.GetModel(() => this.controller.Search("6"));

            Assert.IsTrue(collectionOfCarsFromMakerContainsMost.Count >= 30);
            Assert.IsTrue(collectionOfCarsFromMakerContainsBrother.Count >= 45);
            Assert.IsTrue(collectionOfCarsFromMakerContainsWanted.Count >= 30);
            Assert.IsTrue(collectionOfCarsModelContainsOne.Count >= 36);
            Assert.IsTrue(collectionOfCarsModelContainsSix.Count >= 12);
        }

        [TestMethod]
        public void ExpectAddingDifferaneCarsInRepoThenReturnSortedByMakerToHaveCorrectResult()
        {
            //// IList doesn't have method for Sort.
            List<string> carMakers = new List<string>() { "BMW", "Audi", "GolfSwagen" };
            IList<string> carModels = new List<string>() { "x5", "A7", "Golf 2", "X6", "A7", "Golf 3", "M3", "A8", "Golf 4" };
            Car carToBeAdded;
            IList<Car> carsFromEachGroup = new List<Car>();

            //// Clears all fakeCollection. see Mocks JustMockCarsRepo
            this.fakeCarsData.Remove(new Car());
            Assert.AreEqual(0, this.fakeCarsData.TotalCars);

            for (int i = 0; i < carModels.Count; i++)
            {
                carToBeAdded = new Car
                {
                    Id = (i + 1) * 1000,
                    Make = carMakers[i % carMakers.Count],
                    Model = carModels[i],
                    Year = DateTime.Now.Year - i
                };

                this.controller.Add(carToBeAdded);
            }

            var sortedCarsByMaker = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));
            sortedCarsByMaker.GroupBy(car => car.Make).ToList().ForEach(group => carsFromEachGroup.Add(group.FirstOrDefault()));

            Assert.AreEqual(carMakers.Count, carsFromEachGroup.Count);

            carMakers.Sort();
            for (int i = 0; i < carMakers.Count; i++)
            {
                Assert.AreEqual(carMakers[i], carsFromEachGroup[i].Make);
            }
        }

        [TestMethod]
        public void ExpectAddingCarsInRepoThenReturnSortedByYearToHaveCorrectResults()
        {
            byte specialCounter = 20;
            short[] years = { 2013, 2001, 2004, 2000, 2010 };
            Car fordFocus;
            List<int> expectedResultYears = new List<int>();
            this.fakeCarsData.Remove(new Car());

            for (int i = 0; i < specialCounter; i++)
            {
                fordFocus = new Car()
                {
                    Id = (i + 1) * 1023,
                    Make = "Ford",
                    Model = "Focus F" + i,
                    Year = years[i % years.Length]
                };

                this.controller.Add(fordFocus);
                expectedResultYears.Add(fordFocus.Year);
            }

            var collection = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            expectedResultYears.Sort();

            for (int car = 0; car < expectedResultYears.Count; car++)
            {
                Assert.AreEqual(expectedResultYears[car], collection[car].Year);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid sorting parameter")]
        public void ExpectExceptionWhenWrongParameterPassedToSort()
        {
            var collection = (IList<Car>)this.GetModel(() => this.controller.Sort("id"));
        }

        [TestMethod]
        public void ExpectIDToHasDefaultIntValueWhenCarWithoutIDPased()
        {
            var someCar = new Car()
            {
                Make = "Some",
                Model = "Nowen",
                Year = DateTime.Now.Year
            };

            this.controller.Add(someCar);

            var collection = (IList<Car>)this.GetModel(() => this.controller.Index());
            Car resultCar = collection.First(car => car.Make == "Some");

            Assert.AreEqual(0, resultCar.Id);
        }

        [TestMethod]
        public void ExpectToHaveNormaBehaviorWhenCarsWithSameIDAdded()
        {
            int specialLength = 20;
            int theId = 100;

            var simpleCar = new Car()
            {
                Id = theId,
                Make = "New One",
                Model = "Old One",
                Year = DateTime.Now.Year
            };

            for (int i = 0; i < specialLength; i++)
            {
                simpleCar.Make += i;
                this.controller.Add(simpleCar);
            }

            var collection = (List<Car>)this.GetModel(() => this.controller.Index());
            int count = collection.Count(car => car.Id == theId);

            //// It's hard to define witch one is return while many cars have same Id.
            Assert.AreEqual(specialLength, count);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}