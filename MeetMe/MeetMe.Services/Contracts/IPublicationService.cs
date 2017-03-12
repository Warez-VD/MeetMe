using MeetMe.Data.Models;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IPublicationService
    {
        void CreatePublication(string content, string userId, byte[] imageContent);

        IEnumerable<Publication> FriendsPublications(string userId, int count);

        IEnumerable<Publication> UserPublications(string userId);

        void AddLike(int id);

        void AddDislike(int id);

        Publication GetById(int id);
    }
}
