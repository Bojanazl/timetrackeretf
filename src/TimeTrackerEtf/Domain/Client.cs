using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Domain
{
    public class Client
    {

        public long Id { get; set; }

        [Required] public string Name { get; set; }

    }
}
