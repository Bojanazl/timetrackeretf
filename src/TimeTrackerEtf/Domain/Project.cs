using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Domain
{
    public class Project
    {

        public long id { get; set; }

        public string Name { get; set; }

        public Client Client { get; set; }
    }
}
