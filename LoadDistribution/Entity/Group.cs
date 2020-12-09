using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class Group
    {
        public int GroupID { get; set; }
        public int StudentCount { get; set; }
        public string GroupNum { get; set; }
        public string EducationForm { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", GroupNum, StudentCount, EducationForm);
        }
    }
}
