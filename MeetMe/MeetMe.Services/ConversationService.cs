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

        public ConversationService(
            IEFRepository<Conversation> conversationRepository,
            IUnitOfWork unitOfWork,
            IConversationFactory conversationFactory)
        {
            Guard.WhenArgument(conversationRepository, "ConversationRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(conversationFactory, "ConversationFactory").IsNull().Throw();

            this.conversationRepository = conversationRepository;
            this.unitOfWork = unitOfWork;
            this.conversationFactory = conversationFactory;
        }

        public void CreateConversation(string userId, string friendId)
        {
            var conversation = this.conversationFactory.CreateConversation(userId, friendId);
            this.conversationRepository.Add(conversation);
            this.unitOfWork.Commit();
        }

        public Conversation GetByUserAndFriendId(string userId, string friendId)
        {
            var conversation = this.conversationRepository
                .All
                .Where(x => x.FirstUserId == userId && x.SecondUserId == friendId)
                .FirstOrDefault();

            return conversation;
        }
    }
}
