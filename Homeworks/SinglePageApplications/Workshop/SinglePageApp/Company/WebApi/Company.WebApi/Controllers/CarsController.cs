namespace Company.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using Company.Data.Models;
    using Company.Services.MyServices.Contracts;
    using Company.WebApi.Models.Cars;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    public class CarsController : ApiController
    {
        private ICarsService carsService;

        public CarsController(ICarsService service)
        {
            this.carsService = service;
        }

        public IHttpActionResult Get()
        {
            var topCars = this.carsService
                .All()
                .Take(10)
                .AsQueryable()
                .ProjectTo<CarResponseModel>()
                .ToList();
            return this.Ok(topCars);
        }

        [Authorize]
        [Route("api/cars/{id}")]
        public IHttpActionResult Get(int id)
        {
            var car = this.carsService.GetCarDetails(id);
            return this.Ok(car);
        }

        [Authorize]
        public IHttpActionResult Post(CarRequestModel carRequest)
        {
            if (carRequest == null)
            {
                return this.BadRequest("No data to submit");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            Car carToAdd = Mapper.Map<Car>(carRequest);
            carToAdd.UserId = this.User.Identity.GetUserId();
            int idOfnewlyAdded = this.carsService.Add(carToAdd);

            var answer = Mapper.Map<CarResponseModel>(carToAdd);
            return this.Created("api/cars/" + idOfnewlyAdded, answer);
        }
    }
}