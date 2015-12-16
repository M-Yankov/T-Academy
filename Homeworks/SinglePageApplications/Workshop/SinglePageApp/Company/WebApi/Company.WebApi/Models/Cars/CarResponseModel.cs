namespace Company.WebApi.Models.Cars
{
    using System.Web;
    using Company.Data.Models;
    using Company.WebApi.Infrastructure;

    public class CarResponseModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string UserName { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Car, CarResponseModel>()
                .ForMember(x => x.UserName, opts => opts.MapFrom(z => z.User.UserName));
        }
    }
}