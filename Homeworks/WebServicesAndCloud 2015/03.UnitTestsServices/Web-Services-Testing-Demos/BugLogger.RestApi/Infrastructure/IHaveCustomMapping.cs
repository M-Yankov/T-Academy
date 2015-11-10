namespace BugLogger.RestApi.Infrastructure
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMapping(IConfiguration config);
    }
}