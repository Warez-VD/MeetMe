using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetMe.Web.Hubs
{
    public class Friendship : Hub
    {
        private readonly INotificationService notificationService;
        private readonly IStatisticService statisticService;
        private readonly IUserService userService;

        public Friendship(
            INotificationService notificationService,
            IStatisticService statisticService,
            IUserService userService)
        {
            Guard.WhenArgument(notificationService, "NotificationService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();

            this.notificationService = notificationService;
            this.statisticService = statisticService;
        }

        public void AcceptFriendship(int authorId)
        {

        }
    }
}