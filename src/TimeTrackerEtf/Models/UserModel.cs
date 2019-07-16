using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackerEtf.Domain;

namespace TimeTrackerEtf.Models
{
    /// <summary>
    /// Re[resents one time tracker user.
    /// </summary>
    public class UserModel
    {

        private UserModel()
        {
        }

        /// <summary>
        /// Gts or sets user id/
        /// </summary>

        public long Id { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets how much the user will be paid pet hour.
        /// </summary>

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
