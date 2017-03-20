using System.Data.Entity;
using MeetMe.Data;
using MeetMe.Data.Migrations;

namespace MeetMe.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeetMeDbContext, Configuration>());
            MeetMeDbContext.Create().Database.Initialize(true);
        }
    }
}