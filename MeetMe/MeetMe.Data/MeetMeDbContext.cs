using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        public static MeetMeDbContext Create()
        {
            return new MeetMeDbContext();
        }

        public IDbSet<CustomUser> CustomUsers { get; set; }

        public IDbSet<UserImage> UserImages { get; set; }

        public IDbSet<ProfileImage> ProfileImages { get; set; }

        public IDbSet<Comment> Comments { get; set; }

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
