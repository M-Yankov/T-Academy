namespace Company.WebApi.Controllers
{
    using System;
    using System.Web.Http;
    using Company.Services.MyServices.Contracts;

    public class UsersController : ApiController
    {
        private IUserService userService;

        public UsersController(IUserService service)
        {
            this.userService = service;
        }

        // This controller is for example.
        // TODO: Implement actions. 
    }
}