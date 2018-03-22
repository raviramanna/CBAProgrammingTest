using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeleTextWebApiServer;
using TeleTextWebApiServer.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;


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

        [TestMethod]
        public void PostTeleTextWithStringParam()
        {
            // Set up Prerequisites 
            var sampleText = "SAMPLE TEXT";

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:58592/api/teletext");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "TeleText" } });
            var controller = new TeleTextController();
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            // Act
            var result = controller.Post(sampleText);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
