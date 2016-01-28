namespace WebCounter
{
    using System.Data.Entity;

    public class DbCounterContex : DbContext
    {
        public DbCounterContex()
            : base("Counter")
        {
        }

        public IDbSet<COunter> Counters { get; set; }
    }
}