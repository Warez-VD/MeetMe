using System;
using NUnit.Framework;
using Moq;
using MeetMe.Web.Controllers;

namespace MeetMe.Web.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, null, null, null, null));
        }
    }
}
