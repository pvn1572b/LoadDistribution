using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class Discipline
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassType { get; set; }
        public int TermNum { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, ClassType, TermNum);
        }

    }
}
