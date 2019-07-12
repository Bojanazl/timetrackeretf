using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackerEtf.Domain;

namespace TimeTrackerEtf.Models
{
    public class UserModel
    {

        private UserModel()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public decimal HourRate { get; set; }

        public static UserModel FromUser(User user) //faktori metod
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                HourRate = user.HourRate
            };
        }
    }
}
