using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Notifications;
using MeetMe.Web.Models.Publications;
using MeetMe.Web.Models.Search;

namespace MeetMe.Services.Contracts
{
    public interface IViewModelService
    {
        IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications);

        IEnumerable<NotificationUserViewModel> GetMappedUserNotifications(IEnumerable<Notification> notifications);

        IEnumerable<SearchUserViewModel> GetMappedSearchedUsers(IList<CustomUser> users, string userId);

        IList<CommentViewModel> GetMappedComments(Publication publication);

        ProfilePartialViewModel GetMappedProfile(CustomUser user);

        PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user);
    }
}
