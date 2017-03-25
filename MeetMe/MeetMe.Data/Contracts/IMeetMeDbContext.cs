using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MeetMe.Data.Models;

namespace MeetMe.Data.Contracts
{
    public interface IMeetMeDbContext
    {
        IDbSet<CustomUser> CustomUsers { get; set; }

        IDbSet<UserImage> UserImages { get; set; }

        IDbSet<ProfileImage> ProfileImages { get; set; }

        IDbSet<PublicationImage> PublicationImages { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Publication> Publications { get; set; }

        IDbSet<Statistic> Statistics { get; set; }

        IDbSet<UserFriend> UserFriends { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Conversation> Conversations { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IEntryState<T> GetState<T>(T entity) where T : class;

        int SaveChanges();
    }
}
