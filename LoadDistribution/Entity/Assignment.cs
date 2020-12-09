using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistribution.Entity
{
    public class Assignment
    {
        public int ID { get; set; }

        public Teacher Teacher { get; set; }
        public Guid Guid  { get; set; }
        public int NormHours { get; set; }
        public string PersonalData { get; set; }

        public List<SubItem> SubItems { get; set; }

        public int TotalHours
        {
            get
            {
                int total = 0;
                if (SubItems == null)
                    total = 0;
                else
                {
                    foreach (SubItem si in SubItems)
                    {
                        if (si.Schedule!= null)
                            total += si.Schedule.Hours;
                    }
                }
                return total;

            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Teacher.ToString(), NormHours);
        }

        public Assignment()
        {
            SubItems = new List<SubItem>();
        }

    }
}
