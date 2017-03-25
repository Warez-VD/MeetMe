using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Admin;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Notifications;
using MeetMe.Web.Models.Profile;
using MeetMe.Web.Models.Publications;
using MeetMe.Web.Models.Search;
using MeetMe.Web.Models.Messages;

namespace MeetMe.Services.Contracts
{
    public interface IViewModelService
    {
        IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications);

        IEnumerable<NotificationUserViewModel> GetMappedUserNotifications(IEnumerable<Notification> notifications);

        IEnumerable<SearchUserViewModel> GetMappedSearchedUsers(IList<CustomUser> users, string userId);

        IEnumerable<ProfileFriendViewModel> GetMappedUserFriends(IEnumerable<CustomUser> friends);

        IEnumerable<DashboardViewModel> GetMappedAdminUsers(IEnumerable<CustomUser> users);

        IList<CommentViewModel> GetMappedComments(Publication publication);

        ProfileViewModel GetMappedProfile(CustomUser user);

        ProfilePersonalnfo GetMappedProfilePersonalInfo(CustomUser user);

        ProfilePartialViewModel GetMappedProfilePartial(CustomUser user);

        PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user);

        ConversationViewModel GetMappedConversation(Conversation conversation);
    }
}
