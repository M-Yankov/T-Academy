namespace BugLogger.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BugLogger.DataLayer;

    public class DbBugsRepository : IBugsReposity
    {
        private DbContext dbContext;

        public DbBugsRepository(DbContext context)
        {
            this.dbContext = context;
        }

        public Bug Add(Bug entity)
        {
            //// validation
            this.dbContext.Set<Bug>().Add(entity);
            return entity;
        }

        public IQueryable<Bug> All()
        {
            return this.dbContext.Set<Bug>();
        }

        public void Delete(Bug entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Bug entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Deleted) 
            {
                this.dbContext.Set<Bug>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public Bug Find(int id)
        {
            return this.dbContext.Set<Bug>().Find(id);
        }
    }
}
