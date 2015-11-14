namespace WordOccurance
{
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsProgrammer { get; set; }

        public decimal Money { get; set; }

        public int Age { get; set; }

        public IList<string> Sertificates { get; set; }
    }
}
