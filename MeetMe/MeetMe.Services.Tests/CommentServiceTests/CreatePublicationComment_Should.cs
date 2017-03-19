using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class CreatePublicationComment_Should
    {
        [Test]
        public void CallCommentFactory_CreateCommentOnce()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            
            var commentService = new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object);
            string content = "some content";
            int userId = 12;
            DateTime date = new DateTime(2017, 3, 20);

            // Act
            commentService.CreatePublicationComment(content, userId, date);

            // Assert
            mockedCommentFactory
                .Verify(
                    x => x.CreateComment(
                        It.Is<string>(c => c == content),
                        It.Is<int>(i => i == userId),
                        It.Is<DateTime>(d => d == date)),
                        Times.Once);
        }

        [Test]
        public void CallCommentRepository_AddOnce()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var comment = new Comment();
            mockedCommentFactory
                .Setup(
                    x => x.CreateComment(
                        It.IsAny<string>(),
                        It.IsAny<int>(),
                        It.IsAny<DateTime>()))
                .Returns(comment);

            var commentService = new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object);
            string content = "some content";
            int userId = 12;
            DateTime date = new DateTime(2017, 3, 20);

            // Act
            commentService.CreatePublicationComment(content, userId, date);

            // Assert
            mockedCommentRepository.Verify(x => x.Add(It.Is<Comment>(c => c == comment)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var commentService = new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object);
            string content = "some content";
            int userId = 12;
            DateTime date = new DateTime(2017, 3, 20);

            // Act
            commentService.CreatePublicationComment(content, userId, date);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ReturnComment_Correct()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var comment = new Comment();
            mockedCommentFactory
                .Setup(
                    x => x.CreateComment(
                        It.IsAny<string>(),
                        It.IsAny<int>(),
                        It.IsAny<DateTime>()))
                .Returns(comment);

            var commentService = new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object);
            string content = "some content";
            int userId = 12;
            DateTime date = new DateTime(2017, 3, 20);

            // Act
            var result = commentService.CreatePublicationComment(content, userId, date);

            // Assert
            Assert.AreEqual(result, comment);
        }
    }
}
