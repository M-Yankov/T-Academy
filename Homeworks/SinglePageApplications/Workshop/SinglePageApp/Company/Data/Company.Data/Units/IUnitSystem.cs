namespace Company.Data.Units
{
    using System;
    using Company.Data.Models;
    using Company.Data.Repositories;

    public interface IUnitSystem
    {
        IRepository<User> Users { get; }

        IRepository<Car> Cars { get; }

        int SaveChanges();
    }
}
