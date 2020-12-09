using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class SubItem
    {
        public int SubItemID { get; set; }
        public Group Group{ get; set; }
        public Discipline Discipline { get; set; }
        public Schedule Schedule { get; set; }

        public Guid AssignmentGUID { get; set; }

    }
}
