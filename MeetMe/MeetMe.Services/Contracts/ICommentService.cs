using System;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface ICommentService
    {
        Comment CreatePublicationComment(string content, int userId, DateTime createdOn);
    }
}
