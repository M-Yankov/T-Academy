namespace Company.Services.MyServices.Contracts
{
    using System;
    using System.Linq;
    using Company.Data.Models;

    public interface ICarsService
    {
        IQueryable<Car> All();

        Car GetCarDetails(int id);

        int Add(Car carToAdd);
    }
}
