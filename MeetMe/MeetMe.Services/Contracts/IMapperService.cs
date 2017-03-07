namespace MeetMe.Services.Contracts
{
    public interface IMapperService
    {
        T MapObject<T>(object source);

        T MapObject<K, T>(K source, T destination);
    }
}
