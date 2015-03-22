

namespace P09StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Group
    {
        private int groupnumber;
        private string departamentname;

        public Group(int number , string depName)
        {
            this.GroupNumber = number;
            this.DepartName = depName;
        }

        public int GroupNumber
        {
            get { return this.groupnumber; }
            set { this.groupnumber = value; }
        }


        public string DepartName
        {
            get { return this.departamentname; }
            set { this.departamentname = value; }
        }
        
    }
}
