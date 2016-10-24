using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CM_WAPI;
using CM_WAPI.Controllers;

namespace CM_WAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
