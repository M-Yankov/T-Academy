namespace Company.Services.MyServices
{
    using System.Linq;
    using Company.Data.Models;
    using Company.Data.Units;
    using Company.Services.MyServices.Contracts;

    public class UserService : IUserService
    {
        private IUnitSystem system;

        public UserService(IUnitSystem realEstateSystem)
        {
            this.system = realEstateSystem;
        }
    }
}
