using AutoMapper;

namespace MeetMe.Web.ViewModels.Contracts
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
