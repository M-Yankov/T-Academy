namespace ArtistSystem.WebApi.Infrastructure
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMapping(IConfiguration config);
    }
}
