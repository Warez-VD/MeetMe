using MeetMe.Data.Models;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Notifications;
using MeetMe.Web.Models.Publications;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IViewModelService
    {
        IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications);

        IEnumerable<NotificationUserViewModel> GetMappedUserNotifications(IEnumerable<Notification> notifications);

        IList<CommentViewModel> GetMappedComments(Publication publication);

        ProfilePartialViewModel GetMappedProfile(CustomUser user);

        PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user);
    }
}
