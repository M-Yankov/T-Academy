namespace Company.Services.MyServices
{
    using System.Linq;
    using Company.Data.Models;
    using Company.Data.Units;
    using Company.Services.MyServices.Contracts;

    public class CarsService : ICarsService
    {
        private IUnitSystem carsSystem;

        public CarsService(IUnitSystem sytem)
        {
            this.carsSystem = sytem;
        }

        public IQueryable<Car> All()
        {
            return this.carsSystem.Cars.All();
        }

        public Car GetCarDetails(int id)
        {
            return this.carsSystem.Cars.GetById(id);
        }

        public int Add(Car carToAdd)
        {
           this.carsSystem.Users.GetById(carToAdd.UserId);
            this.carsSystem.Cars.Add(carToAdd);
            this.carsSystem.Cars.SaveChanges();
            return carToAdd.Id;
        }
    }
}
