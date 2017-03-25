using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Admin;
using MeetMe.Web.Models.Home;
using MeetMe.Web.Models.Messages;
using MeetMe.Web.Models.Notifications;
using MeetMe.Web.Models.Profile;
using MeetMe.Web.Models.Publications;
using MeetMe.Web.Models.Search;

namespace MeetMe.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly IMapperService mapperService;
        private readonly IImageService imageService;
        private readonly IUserService userService;
        private readonly IFriendService friendService;

        public ViewModelService(
            IMapperService mapperService,
            IImageService imageService,
            IUserService userService,
            IFriendService friendService)
        {
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();

            this.mapperService = mapperService;
            this.imageService = imageService;
            this.userService = userService;
            this.friendService = friendService;
        }

        public IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications)
        {
            var result = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                var publicationImageUrl = this.imageService.ByteArrayToImageUrl(publication.Image.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;

                mappedPublication.PublicationImageUrl = publicationImageUrl;
                result.Add(mappedPublication);
            }

            return result;
        }

        public IList<CommentViewModel> GetMappedComments(Publication publication)
        {
            var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
            foreach (var publicationComment in mappedPublication.Comments)
            {
                var userLogoUrl = this.imageService.ByteArrayToImageUrl(publicationComment.Image);
                publicationComment.AuthorImageUrl = userLogoUrl;
            }

            var result = mappedPublication.Comments.OrderByDescending(x => x.CreatedOn).ToList();
            return result;
        }

        public ProfilePartialViewModel GetMappedProfilePartial(CustomUser user)
        {
            var profileImageUrl = this.imageService.ByteArrayToImageUrl(user.ProfileImage.Content);
            var result = this.mapperService.MapObject<ProfilePartialViewModel>(user);
            result.ProfileImageUrl = profileImageUrl;

            return result;
        }

        public PersonalInfoViewModel GetMappedPersonalInfo(CustomUser user)
        {
            var profileImageUrl = this.imageService.ByteArrayToImageUrl(user.ProfileImage.Content);

            var result = this.mapperService.MapObject<PersonalInfoViewModel>(user);
            result.ProfileImageUrl = profileImageUrl;

            return result;
        }

        public IEnumerable<NotificationUserViewModel> GetMappedUserNotifications(IEnumerable<Notification> notifications)
        {
            var userImageContents = notifications.Select(x => x.User.ProfileImage.Content).ToList();
            var mappedNotifications = notifications.Select(x => this.mapperService.MapObject<NotificationUserViewModel>(x)).ToList();
            for (int i = 0; i < mappedNotifications.Count; i++)
            {
                var notificationImageUrl = this.imageService.ByteArrayToImageUrl(userImageContents[i]);
                mappedNotifications[i].AuthorImageUrl = notificationImageUrl;
            }

            return mappedNotifications;
        }

        public IEnumerable<SearchUserViewModel> GetMappedSearchedUsers(IList<CustomUser> users, string userId)
        {
            var result = users.Select(x => this.mapperService.MapObject<SearchUserViewModel>(x)).ToList();

            if (userId == string.Empty)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    result[i].ImageUrl = this.imageService.ByteArrayToImageUrl(users[i].ProfileImage.Content);
                }
            }
            else
            {
                var currentUser = this.userService.GetByIndentityId(userId);
                var currentUserFriendsIds = this.friendService.GetAllUserFriendsIds(currentUser.Id);
                for (int i = 0; i < users.Count; i++)
                {
                    bool isFriend = currentUserFriendsIds.Contains(users[i].Id);
                    result[i].IsFriend = isFriend;
                    result[i].ImageUrl = this.imageService.ByteArrayToImageUrl(users[i].ProfileImage.Content);
                }
            }

            return result;
        }

        public IEnumerable<ProfileFriendViewModel> GetMappedUserFriends(IEnumerable<CustomUser> friends)
        {
            var result = new List<ProfileFriendViewModel>();

            foreach (var friend in friends)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(friend.ProfileImage.Content);
                var mappedFriend = this.mapperService.MapObject<ProfileFriendViewModel>(friend);
                mappedFriend.ProfileImageUrl = userImageUrl;

                result.Add(mappedFriend);
            }

            return result;
        }

        public ProfileViewModel GetMappedProfile(CustomUser user)
        {
            var profileImageUrl = this.imageService.ByteArrayToImageUrl(user.ProfileImage.Content);
            var result = this.mapperService.MapObject<ProfileViewModel>(user);
            result.ProfileImageUrl = profileImageUrl;
            result.PersonalInfo = this.GetMappedProfilePersonalInfo(user);

            return result;
        }

        public ProfilePersonalnfo GetMappedProfilePersonalInfo(CustomUser user)
        {
            var result = this.mapperService.MapObject<ProfilePersonalnfo>(user);
            return result;
        }

        public IEnumerable<DashboardViewModel> GetMappedAdminUsers(IEnumerable<CustomUser> users)
        {
            var result = new List<DashboardViewModel>();

            foreach (var user in users)
            {
                var mappedUser = this.mapperService.MapObject<DashboardViewModel>(user);
                result.Add(mappedUser);
            }

            return result;
        }

        public ConversationViewModel GetMappedConversation(Conversation conversation)
        {
            var conversationMessages = conversation.Messages.ToList();
            var result = this.mapperService.MapObject<ConversationViewModel>(conversation);

            for (int i = 0; i < conversationMessages.Count; i++)
            {
                var logoUrl = this.imageService.ByteArrayToImageUrl(conversationMessages[i].User.ProfileImage.Content);
                result.Messages[i].AuthorImageUrl = logoUrl;
            }

            return result;
        }

        public MessageViewModel GetMappedMessage(Message message)
        {
            var result = this.mapperService.MapObject<MessageViewModel>(message);
            var logoUrl = this.imageService.ByteArrayToImageUrl(message.User.ProfileImage.Content);
            result.AuthorImageUrl = logoUrl;
            return result;
        }
    }
}
