namespace ArtistSystem.Data
{
    using System;
    using ArtistsSystem.Models;
    using System.Data.Entity;
    using System.Collections.Generic;

    public class ArtistSystemData : IArtistSystemData
    {
        private DbContext context;
        private IDictionary<Type, object> respositories;

        public ArtistSystemData(DbContext artistContext)
        {
            this.context = artistContext;
            this.respositories = new Dictionary<Type, object>();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
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
                var type = typeof(EfRepository<T>);

                this.respositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.respositories[typeof(T)];
        }
    }
}
