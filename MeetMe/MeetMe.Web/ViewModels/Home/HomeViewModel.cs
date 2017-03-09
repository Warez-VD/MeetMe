using System.Collections.Generic;

namespace MeetMe.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public LoginViewModel Login { get; set; }

        public RegisterViewModel Register { get; set; }

        public PersonalInfoViewModel PersonalInfo { get; set; }

        public IEnumerable<PublicationViewModel> Publications { get; set; }
    }
}