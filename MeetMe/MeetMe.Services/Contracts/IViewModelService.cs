using MeetMe.Data.Models;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Publications;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IViewModelService
    {
        IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications);

        IList<CommentViewModel> GetMappedComments(Publication publication);

        ProfilePartialViewModel GetMappedProfile(CustomUser user);

        PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user);
    }
}
