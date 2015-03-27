using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    abstract class People
    {
        

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
    }
}
