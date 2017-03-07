using AutoMapper;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class MapperService : IMapperService
    {
        public T MapObject<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public T MapObject<K, T>(K source, T destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}
