namespace BugLogger.Repositories
{
    using System.Linq;
    using BugLogger.DataLayer;

    public interface IBugsReposity : IRepository<Bug>
    {
        Bug Find(int id);

        Bug Add(Bug entity);

        IQueryable<Bug> All();

        void Delete(Bug entity);

        void Update(Bug entity);

        void Save();
    }
}
