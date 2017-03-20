using System;
using MeetMe.Web.Controllers;
using NUnit.Framework;

namespace MeetMe.Web.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, null, null, null));
        }
    }
}
