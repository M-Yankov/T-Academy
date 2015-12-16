namespace Company.WebApi.WcfClient
{
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data.Units;

    public class UsersService : IUsersService
    {
        private IUnitSystem system;

        public UsersService(IUnitSystem sys)
        {
            this.system = sys;
        }

        public IEnumerable<int> GetUsers()
        {
            // TODO: Replace int with UserResponseModel
            return Enumerable.Range(1, 10);
        }
    }
}
