using System.ComponentModel.DataAnnotations;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Profile
{
    public class ProfilePersonalnfo : IMapFrom<CustomUser>
    {
        public int Id { get; set; }

        [RegularExpression("^[\\s\\S]{3,50}$", ErrorMessage = "First name must be between 3 and 50 symbols")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [RegularExpression("^[\\s\\S]{3,50}$", ErrorMessage = "Last name must be between 3 and 50 symbols")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        [RegularExpression("^[\\s\\S]{0,100}$", ErrorMessage = "School name must not be more than 100 symbols")]
        public string School { get; set; }

        [RegularExpression("^[\\s\\S]{0,100}$", ErrorMessage = "Company name must not be more than 100 symbols")]
        public string Company { get; set; }
    }
}
