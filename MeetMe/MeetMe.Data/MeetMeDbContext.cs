using System.Data.Entity;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeetMe.Data
{
    public class MeetMeDbContext : IdentityDbContext<AspIdentityUser>, IMeetMeDbContext
    {
        private IStateFactory stateFactory;

        public MeetMeDbContext()
            : base("MeetMeDB")
        {
        }

        public MeetMeDbContext(IStateFactory stateFactory)
            : base("MeetMeDB")
        {
            Guard.WhenArgument(stateFactory, "StateFactory").IsNull().Throw();

            this.stateFactory = stateFactory;
        }

        public virtual IDbSet<CustomUser> CustomUsers { get; set; }
               
        public virtual IDbSet<UserImage> UserImages { get; set; }
               
        public virtual IDbSet<ProfileImage> ProfileImages { get; set; }
               
        public virtual IDbSet<PublicationImage> PublicationImages { get; set; }
               
        public virtual IDbSet<Comment> Comments { get; set; }
               
        public virtual IDbSet<Publication> Publications { get; set; }
               
        public virtual IDbSet<Statistic> Statistics { get; set; }

        public virtual IDbSet<UserFriend> UserFriends { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public static MeetMeDbContext Create()
        {
            return new MeetMeDbContext();
        }

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IEntryState<T> GetState<T>(T entity) where T : class
        {
            return this.stateFactory.CreateState(this.Entry(entity));
        }
    }
}
