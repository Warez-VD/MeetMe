using AutoMapper;

namespace MeetMe.Web.Models.Contracts
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
