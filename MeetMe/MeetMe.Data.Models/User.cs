using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetMe.Data.Models
{
    public class User
    {
        public User(string firstName, string lastName, string aspIdentityUserId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AspIdentityUserId = aspIdentityUserId;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AspIdentityUserId { get; set; }
    }
}
