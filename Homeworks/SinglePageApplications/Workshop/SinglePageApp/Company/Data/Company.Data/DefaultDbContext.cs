namespace Company.Data
{
    using System;
    using System.Data.Entity;
    using Company.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DefaultDbContext : IdentityDbContext<User>
    {
        public DefaultDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Car> Cars { get; set; }

        public static DefaultDbContext Create()
        {
            return new DefaultDbContext();
        }
    }
}
