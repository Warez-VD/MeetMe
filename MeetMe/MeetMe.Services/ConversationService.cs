using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IEFRepository<Conversation> conversationRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConversationFactory conversationFactory;
        private readonly IMessageService messageService;

        public ConversationService(
            IEFRepository<Conversation> conversationRepository,
            IUnitOfWork unitOfWork,
            IConversationFactory conversationFactory,
            IMessageService messageService)
        {
            Guard.WhenArgument(conversationRepository, "ConversationRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(conversationFactory, "ConversationFactory").IsNull().Throw();
            Guard.WhenArgument(messageService, "MessageService").IsNull().Throw();

            this.conversationRepository = conversationRepository;
            this.unitOfWork = unitOfWork;
            this.conversationFactory = conversationFactory;
            this.messageService = messageService;
        }

        public void CreateConversation(string userId, string friendId)
        {
            var conversation = this.conversationFactory.CreateConversation(userId, friendId);
            this.conversationRepository.Add(conversation);
            this.unitOfWork.Commit();
        }

        public Conversation GetByUserId(string userId)
        {
            var conversation = this.conversationRepository
                .All
                .Where(x => x.FirstUserId == userId || x.SecondUserId == userId)
                .FirstOrDefault();

            return conversation;
        }

        public Message AddMessageToConversation(CustomUser user, string userId, string content)
        {
            var message = this.messageService.CreateMessage(user, content);

            var conversation = this.GetByUserId(userId);
            conversation.Messages.Add(message);
            this.conversationRepository.Update(conversation);
            this.unitOfWork.Commit();

            return message;
        }
    }
}
