using System.Collections.Generic;
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
    public class ShowMoreResults_Should
    {
        [Test]
        public void ReturnSearchResultPartialView()
        {
            // Arrange
            var mockedSearchService = new Mock<ISearchService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var searchController = new SearchController(
                mockedSearchService.Object,
                mockedViewModelService.Object,
                mockedIdentityHelper.Object);
            string pattern = "some";
            int skip = 2;
            int count = 3;
            string userId = "some-id";

            // Act & Assert
            searchController
                .WithCallTo(x => x.ShowMoreResults(pattern, skip, count, userId))
                .ShouldRenderPartialView("_SearchResultsPartial")
                .WithModel<IEnumerable<SearchUserViewModel>>();
        }
    }
}
