using System;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface ICommentFactory
    {
        Comment CreateComment(string content, int userId, DateTime createdOn);
    }
}
