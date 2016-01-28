using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars
{
    public class Producer
    {
        public string Name { get; set; }

        public ICollection<CarModel> Models { get; set; }
    }
}