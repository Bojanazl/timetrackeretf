using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Domain
{
    public class TimeEntry
    {

        public long Id { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }

        public DateTime EntryDate { get; set; }

        public int Hours { get; set; }

        public string Description { get; set; }

        public decimal HourRate { get; set; }
    }
}
