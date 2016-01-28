namespace CountriesDataBase
{
    using System.Collections.Generic;

    public class Contintent
    {
        private ICollection<Country> contries;

        public Contintent()
        {
            this.contries = new HashSet<Country>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Country> Countries
        {
            get
            {
                return this.contries;
            }
            set
            {
                this.Countries = value;
            }
        }
    }
}