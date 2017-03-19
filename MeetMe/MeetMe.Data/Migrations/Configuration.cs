using System.Data.Entity.Migrations;

namespace MeetMe.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MeetMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
