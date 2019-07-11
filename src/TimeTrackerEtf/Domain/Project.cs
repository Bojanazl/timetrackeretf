using System.ComponentModel.DataAnnotations;

namespace TimeTrackerEtf.Domain
{
    public class Project
    {

        public long id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public Client Client { get; set; }
    }
}
