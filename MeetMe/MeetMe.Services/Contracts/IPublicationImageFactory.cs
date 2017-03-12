using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IPublicationImageFactory
    {
        PublicationImage CreatePublicationImage(byte[] content);
    }
}
