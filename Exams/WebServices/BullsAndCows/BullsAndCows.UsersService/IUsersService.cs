namespace BullsAndCows.UsersService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Models;

    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/users?page={page}")]
        IEnumerable<UserResponseModel> GetAllUsers(string page = "1");

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/users/{id}")]
        DetailUserModel GetDetailsForUser(string id);
    }
}
