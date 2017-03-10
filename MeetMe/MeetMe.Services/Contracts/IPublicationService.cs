using MeetMe.Data.Models;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IPublicationService
    {
        void CreatePublication(string content, string userId);

        IEnumerable<Publication> FriendsPublications(string userId, int count);

        IEnumerable<Publication> UserPublications(string userId);
    }
}
