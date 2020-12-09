using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class Schedule
    {
        public int ID { get; set; }
        public Group Group{ get; set; }
        public Discipline Discipline{ get; set; }
        public int Hours { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} часов", Group.GroupNum, Discipline.Name, Hours);
        }

    }
}
