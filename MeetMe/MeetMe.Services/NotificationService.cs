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

        public NotificationService(
            IEFRepository<Notification> notificationRepository,
            IDateTimeService dateTimeService,
            INotificationFactory notificationFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(notificationRepository, "NotificationRepository").IsNull().Throw();
            Guard.WhenArgument(dateTimeService, "DateTimeService").IsNull().Throw();
            Guard.WhenArgument(notificationFactory, "NotificationFactory").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();

            this.notificationRepository = notificationRepository;
            this.dateTimeService = dateTimeService;
            this.notificationFactory = notificationFactory;
            this.unitOfWork = unitOfWork;
        }

        public void CreateNotification(int userId, string content, bool isFriendship)
        {
            var date = this.dateTimeService.GetCurrentDate();
            var notification = this.notificationFactory.CreateNotification(userId, content, date, isFriendship);
            this.notificationRepository.Add(notification);
            this.unitOfWork.Commit();
        }
    }
}
