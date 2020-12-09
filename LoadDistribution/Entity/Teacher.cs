using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public string Chair { get; set; }
        public string Post { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, LastName, Patronimyc);
        }

    }
}
