using AutoMapper;
using MeetMe.Web.App_Start.AutomapperProfiles;

namespace MeetMe.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public static void Execute()
        {
            Mapper.Initialize(AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new ModelsProfile());
        }
    }
}