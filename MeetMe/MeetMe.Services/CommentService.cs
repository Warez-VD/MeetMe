using System;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class CommentService : ICommentService
    {
        private readonly IEFRepository<Comment> commentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommentFactory commentFactory;

        public CommentService(
            IEFRepository<Comment> commentRepository,
            IUnitOfWork unitOfWork,
            ICommentFactory commentFactory)
        {
            Guard.WhenArgument(commentRepository, "CommentRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(commentFactory, "CommentFactory").IsNull().Throw();

            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
            this.commentFactory = commentFactory;
        }

        public Comment CreatePublicationComment(string content, int userId, DateTime createdOn)
        {
            var comment = this.commentFactory.CreateComment(content, userId, createdOn);
            this.commentRepository.Add(comment);
            this.unitOfWork.Commit();
            return comment;
        }
    }
}
