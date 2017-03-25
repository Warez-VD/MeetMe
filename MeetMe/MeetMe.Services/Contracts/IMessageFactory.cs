using System;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IMessageFactory
    {
        Message CreateMessage(string content, CustomUser user, DateTime createdOn);
    }
}
