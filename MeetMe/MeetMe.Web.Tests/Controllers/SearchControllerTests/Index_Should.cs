using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Helpers.Contracts;
using MeetMe.Web.Models.Search;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.SearchControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallIdentityHelper_GetCurrentUserIdOnce_OnGET()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<CustomUser>());
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);

            // Act
            searchController.Index();

            // Assert
            mockedIdentityHelper.Verify(x => x.GetCurrentUserId(), Times.Once);
        }

        [Test]
        public void CallSearchService_SearchedUsersOnce_OnGET()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<CustomUser>());
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            mockedIdentityHelper.Setup(x => x.GetCurrentUserId()).Returns("user-id-xx");

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);

            // Act
            searchController.Index();

            // Assert
            mockedSearchService.Verify(x => x.SearchedUsers(string.Empty, 0, 5), Times.Once);
        }

        [Test]
        public void CallViewModelService_GetMappedSearchedUsers_WithFoundUsers_OnGET()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var results = new List<CustomUser>()
                {
                    new CustomUser(),
                    new CustomUser(),
                    new CustomUser()
                };
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(results);
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            string userId = "user-id-xx";
            mockedIdentityHelper.Setup(x => x.GetCurrentUserId()).Returns(userId);

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);

            // Act
            searchController.Index();

            // Assert
            mockedViewModelService.Verify(x => x.GetMappedSearchedUsers(results, userId), Times.Once);
        }

        [Test]
        public void RedirectIfUserIsnAuthenticated_OnGET()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var results = new List<CustomUser>()
                {
                    new CustomUser(),
                    new CustomUser(),
                    new CustomUser()
                };
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(results);
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);

            // Act & Assert
            searchController.WithCallTo(x => x.Index())
                .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Index"));
        }

        [Test]
        public void ReturnDefaultView_WithModel_OnGET()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var results = new List<CustomUser>()
                {
                    new CustomUser(),
                    new CustomUser(),
                    new CustomUser()
                };
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(results);
            var mockedViewModelService = new Mock<IViewModelService>();
            var mappedUsers = new List<SearchUserViewModel>()
            {
                new SearchUserViewModel(),
                new SearchUserViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedSearchedUsers(It.IsAny<IList<CustomUser>>(), It.IsAny<string>())).Returns(mappedUsers);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            string userId = "user-id-xx";
            mockedIdentityHelper.Setup(x => x.GetCurrentUserId()).Returns(userId);

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);

            // Act & Assert
            searchController.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<SearchViewModel>(m => 
                {
                    Assert.AreEqual(string.Empty, m.SearchedPattern);
                    Assert.AreEqual(results.Count, m.ResultsCount);
                    Assert.AreEqual(mappedUsers, m.FoundUsers);
                });
        }

        [Test]
        public void CallSearchService_SearchedUsersOnce_OnPOST()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<CustomUser>());
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            mockedIdentityHelper.Setup(x => x.GetCurrentUserId()).Returns("user-id-xx");

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);
            string pattern = "some";
            int skip = 5;
            int count = 2;
            string userId = "user-id-xx";

            // Act
            searchController.Index(pattern, skip, count, userId);

            // Assert
            mockedSearchService.Verify(x => x.SearchedUsers(pattern, skip, count), Times.Once);
        }

        [Test]
        public void CallViewModelService_GetMappedSearchedUsers_WithFoundUsers_OnPOST()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var results = new List<CustomUser>()
                {
                    new CustomUser(),
                    new CustomUser(),
                    new CustomUser()
                };
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(results);
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            string userId = "user-id-xx";
            mockedIdentityHelper.Setup(x => x.GetCurrentUserId()).Returns(userId);

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);
            string pattern = "some";
            int skip = 5;
            int count = 2;

            // Act
            searchController.Index(pattern, skip, count, userId);

            // Assert
            mockedViewModelService.Verify(x => x.GetMappedSearchedUsers(results, userId), Times.Once);
        }

        [Test]
        public void ReturnDefaultView_WithModel_OnPOST()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var results = new List<CustomUser>()
                {
                    new CustomUser(),
                    new CustomUser(),
                    new CustomUser()
                };
            mockedSearchService.Setup(x => x.SearchedUsers(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(results);
            var mockedViewModelService = new Mock<IViewModelService>();
            var mappedUsers = new List<SearchUserViewModel>()
            {
                new SearchUserViewModel(),
                new SearchUserViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedSearchedUsers(It.IsAny<IList<CustomUser>>(), It.IsAny<string>())).Returns(mappedUsers);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            
            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);
            string pattern = "some";
            int skip = 5;
            int count = 2;
            string userId = "user-id-xx";

            // Act & Assert
            searchController.WithCallTo(x => x.Index(pattern, skip, count, userId))
                .ShouldRenderDefaultView()
                .WithModel<SearchViewModel>(m =>
                {
                    Assert.AreEqual(pattern, m.SearchedPattern);
                    Assert.AreEqual(results.Count, m.ResultsCount);
                    Assert.AreEqual(mappedUsers, m.FoundUsers);
                });
        }
    }
}
