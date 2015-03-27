
namespace P03AnimalHierarhy
{
    using System;
    using System.Text;
    abstract class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Sex PSex { get; set; }

        public override string ToString()
        {
            return String.Format("{0} Name: {1} Age: {2} Sex: {3}", this.GetType().Name, this.Name, this.Age, this.PSex);
        }
    }
}
