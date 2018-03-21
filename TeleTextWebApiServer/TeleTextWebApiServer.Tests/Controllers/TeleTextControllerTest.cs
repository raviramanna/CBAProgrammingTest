using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeleTextWebApiServer;
using TeleTextWebApiServer.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace TeleTextWebApiServer.Tests.Controllers
{
    [TestClass]
    public class TeletextControllerTest
    {
        [TestMethod]
        public void GetTeleText()
        {
            // Set up Prerequisites   
            var controller = new TeleTextController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var id = 1;
            // Act on Test  
            var response = controller.Get();
            // Assert the result  
            foreach (var line in response)
            {
                Assert.AreEqual("TeleText"+id, line);
                id++;
            }
        }

        [TestMethod]
        public void GetTeleTextWithId()
        {
            // Set up Prerequisites   
            var controller = new TeleTextController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var id = 1;
            // Act on Test  
            var response = controller.Get(id);
            // Assert the result  
            
            Assert.AreEqual("TeleText" + id, response);
        }
    }
}
