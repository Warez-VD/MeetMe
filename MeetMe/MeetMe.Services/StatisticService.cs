using MeetMe.Services.Contracts;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Data.Contracts;
using Bytes2you.Validation;
using System;

namespace MeetMe.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUserService userService;
        private readonly IEFRepository<Statistic> statisticRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStatisticFactory statisticFactory;

        public StatisticService(
            IUserService userService,
            IEFRepository<Statistic> statisticRepository,
            IUnitOfWork unitOfWork,
            IStatisticFactory statisticFactory)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(statisticRepository, "StatisticRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(statisticFactory, "StatisticFactory").IsNull().Throw();

            this.userService = userService;
            this.statisticRepository = statisticRepository;
            this.unitOfWork = unitOfWork;
            this.statisticFactory = statisticFactory;
        }

        public void AddMessageStatistic(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var statistic = this.statisticRepository.All.Where(x => x.CustomUserId == user.Id).FirstOrDefault();
            statistic.MessagesCount++;
            this.statisticRepository.Update(statistic);
            this.unitOfWork.Commit();
        }

        public void AddNotificationStatistic(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var statistic = this.statisticRepository.All.Where(x => x.CustomUserId == user.Id).FirstOrDefault();
            statistic.NotificationsCount++;
            this.statisticRepository.Update(statistic);
            this.unitOfWork.Commit();
        }

        public void AddNotificationStatistic(int userId)
        {
            var statistic = this.statisticRepository.All.Where(x => x.CustomUserId == userId).FirstOrDefault();
            statistic.NotificationsCount++;
            this.statisticRepository.Update(statistic);
            this.unitOfWork.Commit();
        }

        public void CreateStatistic(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var statistic = this.statisticFactory.CreateStatistic(0, 0, user.Id);
            this.statisticRepository.Add(statistic);
            this.unitOfWork.Commit();
        }

        public Statistic GetUserStatistic(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var statistic = this.statisticRepository.All.Where(x => x.CustomUserId == user.Id).FirstOrDefault();

            return statistic;
        }

        public void MarkAsVisitedNotifications(string userId)
        {
            var statistic = this.GetUserStatistic(userId);
            statistic.NotificationsCount = 0;
            this.statisticRepository.Update(statistic);
            this.unitOfWork.Commit();
        }

        public void RemoveNotificationStatistic(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var statistic = this.statisticRepository.All.Where(x => x.CustomUserId == user.Id).FirstOrDefault();
            statistic.NotificationsCount--;
            this.statisticRepository.Update(statistic);
            this.unitOfWork.Commit();
        }
    }
}
