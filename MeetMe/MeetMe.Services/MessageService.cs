using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class MessageService : IMessageService
    {
        private readonly IEFRepository<Message> messageRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageFactory messageFactory;
        private readonly IDateTimeService dateTimeService;

        public MessageService(
            IEFRepository<Message> messageRepository,
            IUnitOfWork unitOfWork,
            IMessageFactory messageFactory,
            IDateTimeService dateTimeService)
        {
            Guard.WhenArgument(messageRepository, "MessageRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(messageFactory, "MessageFactory").IsNull().Throw();
            Guard.WhenArgument(dateTimeService, "DateTimeService").IsNull().Throw();

            this.messageRepository = messageRepository;
            this.unitOfWork = unitOfWork;
            this.messageFactory = messageFactory;
            this.dateTimeService = dateTimeService;
        }

        public Message CreateMessage(CustomUser user, string content)
        {
            var date = this.dateTimeService.GetCurrentDate();
            var message = this.messageFactory.CreateMessage(content, user, date);

            this.messageRepository.Add(message);
            this.unitOfWork.Commit();

            return message;
        }
    }
}
