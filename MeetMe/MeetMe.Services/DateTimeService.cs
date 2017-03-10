using System;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
