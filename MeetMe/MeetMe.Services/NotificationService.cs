using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEFRepository<Notification> notificationRepository;
        private readonly IDateTimeService dateTimeService;
        private readonly INotificationFactory notificationFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;

        public NotificationService(
            IEFRepository<Notification> notificationRepository,
            IDateTimeService dateTimeService,
            INotificationFactory notificationFactory,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            Guard.WhenArgument(notificationRepository, "NotificationRepository").IsNull().Throw();
            Guard.WhenArgument(dateTimeService, "DateTimeService").IsNull().Throw();
            Guard.WhenArgument(notificationFactory, "NotificationFactory").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();

            this.notificationRepository = notificationRepository;
            this.dateTimeService = dateTimeService;
            this.notificationFactory = notificationFactory;
            this.unitOfWork = unitOfWork;
            this.userService = userService;
        }

        public void CreateNotification(int userId, string content, bool isFriendship, int targetId)
        {
            var date = this.dateTimeService.GetCurrentDate();
            var notification = this.notificationFactory.CreateNotification(userId, content, date, isFriendship, targetId);
            
            this.notificationRepository.Add(notification);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Notification> UserNotifications(int skip, int count, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);

            var notifications = this.notificationRepository.All
                .Where(x => x.TargetUserId == user.Id && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip)
                .Take(count)
                .ToList();

            return notifications;
        }

        public void RemoveNotification(int id)
        {
            var notification = this.notificationRepository.GetById(id);
            notification.IsDeleted = true;
            this.notificationRepository.Update(notification);
            this.unitOfWork.Commit();
        }

        public void RemoveAllNotifications(string userId)
        {
            var notifications = this.notificationRepository.All
                .Where(x => x.User.AspIdentityUserId == userId && x.IsDeleted == false);

            foreach (var notification in notifications)
            {
                notification.IsDeleted = true;
                this.notificationRepository.Update(notification);
            }

            this.unitOfWork.Commit();
        }
    }
}
