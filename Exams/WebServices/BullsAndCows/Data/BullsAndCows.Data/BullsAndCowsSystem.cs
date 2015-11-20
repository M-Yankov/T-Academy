namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class BullsAndCowsSystem : IBullsAndCowsSystem
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> respositories;

        public BullsAndCowsSystem(DbContext bullsAndCowsContext)
        {
            this.context = bullsAndCowsContext;
            this.respositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<Player> Players
        {
            get
            {
                return this.GetRepository<Player>();
            }
        }

        public IRepository<Guess> Guesses
        {
            get
            {
                return this.GetRepository<Guess>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.respositories.ContainsKey(typeof(T)))
            {
                Type type = typeof(GenericRepository<T>);

                this.respositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.respositories[typeof(T)];
        }
    }
}
