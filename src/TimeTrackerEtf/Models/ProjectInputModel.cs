using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackerEtf.Domain;

namespace TimeTrackerEtf.Models
{
    public class ProjectInputModel
    {
        public string Name { get; set; }

        public long ClientId { get; set; }

        public void MapTo(Project project)
        {
            project.Name = Name; 
        }
    }
}
