namespace Company.WebApi.WcfClient
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IUsersService
    {
        /// <summary>
        /// If you want json ResponseFormat = WebMessageFormat.json
        /// </summary>
        /// <returns>You must return a response model of user.</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/users/top.svc")]
        IEnumerable<int> GetUsers();
    }
}