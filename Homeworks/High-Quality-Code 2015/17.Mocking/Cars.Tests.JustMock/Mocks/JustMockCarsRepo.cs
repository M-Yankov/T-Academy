namespace Cars.Tests.JustMock.Mocks
{
    using System;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Models;
    using Telerik.JustMock;

    public class JustMockCarsRepo : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();

            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoInstead<Car>(car => this.FakeCarCollection.Add(car));
            Mock.Arrange(() => this.CarsData.Search(Arg.Matches<string>(str => str != null)))
                .Returns<string>(str => this.FakeCarCollection.Where(c =>
                                                                         c.Make.ToLower().Contains(str.ToLower()) ||
                                                                         c.Model.ToLower().Contains(str.ToLower())).ToList());
            
            Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt))
                .When<int>(id => this.FakeCarCollection.All(car => car.Id != id))
                .DoNothing();

            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(() => this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(() => this.FakeCarCollection.OrderBy(c => c.Year).ToList());

            Mock.Arrange(() => this.CarsData.Remove(Arg.IsAny<Car>())).DoInstead(() => this.FakeCarCollection.Clear());
            Mock.Arrange(() => this.CarsData.GetById(Arg.Is<int>(100))).Returns<int>(id => this.FakeCarCollection.FirstOrDefault(car => car.Id == id));
        }
    }
}