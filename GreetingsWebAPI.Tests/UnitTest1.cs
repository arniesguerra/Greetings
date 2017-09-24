using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GreetingsWebAPI.Controllers;
using GreetingsWebAPI.Models;
using System.Web.Http.Results;

namespace GreetingsWebAPI.Tests
{
    [TestClass]
    public class TestGreetings
    {
        [TestMethod]
        public void GetAllGreetings()
        {
            var testGreetings = GetTestGreetings();
            var controller = new GreetingsController(testGreetings);

            var result = controller.GetAllGreetings() as List<Greeting>;
            Assert.AreEqual(testGreetings.Count, result.Count);
        }

        [TestMethod]
        public void GetGreeting()
        {
            var testGreetings = GetTestGreetings();
            var controller = new GreetingsController(testGreetings);

            var result = controller.GetGreeting(4) as OkNegotiatedContentResult<Greeting>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testGreetings[3].Message, result.Content.Message);
        }

        private List<Greeting> GetTestGreetings()
        {
            var testGreetings = new List<Greeting>();
            testGreetings.Add(new Greeting { Id = 1, Message = "Hello World1" });
            testGreetings.Add(new Greeting { Id = 2, Message = "Hello World2" });
            testGreetings.Add(new Greeting { Id = 3, Message = "Hello World3" });
            testGreetings.Add(new Greeting { Id = 4, Message = "Hello World4" });

            return testGreetings;
        }
    }
}
