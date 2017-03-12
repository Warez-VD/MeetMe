using System;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IPublicationFactory
    {
        Publication CreatePublication(string content, int userId, DateTime createdOn);

        Publication CreatePublication(string content, int userId, DateTime createdOn, PublicationImage image);
    }
}
