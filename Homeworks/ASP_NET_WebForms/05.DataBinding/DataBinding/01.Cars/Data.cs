using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars
{
    public class Data
    {
        // Audi
        private CarModel a4 = new CarModel() { Name = "A4" };
        private CarModel a7 = new CarModel() { Name = "A7" };
        private CarModel a8 = new CarModel() { Name = "A8" };
        private CarModel s4 = new CarModel() { Name = "S4" };

        // BMW
        private CarModel m3 = new CarModel() { Name = "M3" };
        private CarModel z3 = new CarModel() { Name = "Z3" };
        private CarModel z6 = new CarModel() { Name = "Z6" };
        
        // VW
        private CarModel golf = new CarModel() { Name = "Golf" };
        private CarModel passat = new CarModel() { Name = "Passat" };
        private CarModel polo = new CarModel() { Name = "Polo" };


        public ICollection<Producer> GetProducers()
        {
            Producer bmw = new Producer() { Name = "BMW", Models = new List<CarModel>() { m3, z3, z6 } };
            Producer audi = new Producer() { Name = "Audi", Models = new List<CarModel>() { a4, a7, a8, s4 } };
            Producer volkswagen = new Producer() { Name = "Volkswagen", Models = new List<CarModel>() { golf, passat, polo } };

            return new List<Producer>() { bmw, audi, volkswagen };
        }

        public ICollection<Car> ProvideCars()
        {
            Producer bmw = new Producer() { Name = "BMW", Models = new List<CarModel>() { m3, z3, z6 } };
            Producer audi = new Producer() { Name = "Audi", Models = new List<CarModel>() { a4, a7, a8, s4 } };
            Producer volkswagen = new Producer() { Name = "Volkswagen", Models = new List<CarModel>() { golf, passat, polo } };

            return new List<Car>()
            {
                new Car(Engine.Electric, bmw, z3, 1999, 2000, Condition.Used),
                new Car(Engine.Diesel, bmw, z3, 1993, 1150, Condition.Used),
                new Car(Engine.Diesel, bmw, z3, 2001, 3500, Condition.Used),
                new Car(Engine.Gasoline, bmw, z3, 2003, 5100, Condition.Used),
                new Car(Engine.Gasoline, bmw, m3, 1996, 3999, Condition.Used),
                new Car(Engine.Gasoline, bmw, m3, 2013, 16000, Condition.New),
                new Car(Engine.Diesel, bmw, m3, 2009, 18500, Condition.New),
                new Car(Engine.Diesel, bmw, z6, 2003, 6100, Condition.Used),
                new Car(Engine.Hybrid, bmw, z6, 2000, 12050, Condition.Used),
                new Car(Engine.Electric, bmw, z6, 2010, 20100, Condition.New),
                new Car(Engine.Hybrid, bmw, z6, 2008, 10900, Condition.Used),

                new Car(Engine.Gasoline, audi, a4, 2000, 13000, Condition.Used),
                new Car(Engine.Electric, audi, a4, 2016, 15000, Condition.Used),
                new Car(Engine.Electric, audi, a4, 2001, 15000, Condition.New),
                new Car(Engine.Gasoline, audi, a7, 2006, 1670, Condition.OnParts),
                new Car(Engine.Gasoline, audi, a7, 2001, 16700, Condition.New),
                new Car(Engine.Diesel, audi, a7, 2005, 6500, Condition.Used),
                new Car(Engine.Gasoline, audi, a7, 1999, 4210, Condition.Used),
                new Car(Engine.Gasoline, audi, a8, 2003, 6500, Condition.Used),
                new Car(Engine.Diesel, audi, a8, 2002, 20100, Condition.New),
                new Car(Engine.Diesel, audi, s4, 2000, 6120, Condition.OnParts),
                new Car(Engine.Gasoline, audi, s4, 2006, 5100, Condition.Used),

                new Car(Engine.Gasoline, volkswagen, golf, 2002, 11300, Condition.New),
                new Car(Engine.Diesel, volkswagen, golf, 1995, 1300, Condition.Used),
                new Car(Engine.Gasoline, volkswagen, golf, 2009, 21300, Condition.New),
                new Car(Engine.Electric, volkswagen, polo, 2006, 3300, Condition.Used),
                new Car(Engine.Gasoline, volkswagen, polo, 2001, 1100, Condition.OnParts),
                new Car(Engine.Hybrid, volkswagen, passat, 2006, 4900, Condition.Used),
                new Car(Engine.Diesel, volkswagen, passat, 2011, 10300, Condition.New),
                new Car(Engine.Diesel, volkswagen, passat, 2001, 5100, Condition.Used),
                new Car(Engine.Diesel, volkswagen, passat, 2008, 4990, Condition.Used),
                new Car(Engine.Gasoline, volkswagen, passat, 2012, 23480, Condition.New),
                new Car(Engine.Electric, volkswagen, polo, 2007, 1300, Condition.OnParts)
            };
        }
    }
}