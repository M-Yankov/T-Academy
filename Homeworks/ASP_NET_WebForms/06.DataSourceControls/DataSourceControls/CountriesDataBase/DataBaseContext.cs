using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesDataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
                : base("CountriesDB")
        {
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Contintent> Contintents { get; set; }
        
    }
}
