using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Notifications;
using MeetMe.Web.Models.Publications;
using MeetMe.Web.Models.Search;
using MeetMe.Web.Models.Profile;

namespace MeetMe.Services.Contracts
{
    public interface IViewModelService
    {
        IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications);

        IEnumerable<NotificationUserViewModel> GetMappedUserNotifications(IEnumerable<Notification> notifications);

        IEnumerable<SearchUserViewModel> GetMappedSearchedUsers(IList<CustomUser> users, string userId);

        IEnumerable<ProfileFriendViewModel> GetMappedUserFriends(IEnumerable<CustomUser> friends);

        IList<CommentViewModel> GetMappedComments(Publication publication);

        ProfileViewModel GetMappedProfile(CustomUser user);

        ProfilePartialViewModel GetMappedProfilePartial(CustomUser user);

        PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user);
    }
}
