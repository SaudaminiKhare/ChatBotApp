using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatBot;
using ChatBot.Controllers;

namespace ChatBot.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Initialize
            ValuesController controller = new ValuesController();

            // act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
            Assert.AreEqual("M_0001", result.ElementAt(0));
            Assert.AreEqual("M_0002", result.ElementAt(1));
            Assert.AreEqual("M_0003", result.ElementAt(2));
            Assert.AreEqual("M_0004", result.ElementAt(3));
            Assert.AreEqual("M_0005", result.ElementAt(4));
            Assert.AreEqual("M_0006", result.ElementAt(5));
            Assert.AreEqual("M_0007", result.ElementAt(6));
            Assert.AreEqual("M_0008", result.ElementAt(7));
            Assert.AreEqual("M_0009", result.ElementAt(8));
            Assert.AreEqual("M_0010", result.ElementAt(9));
        }

        [TestMethod]
        public void GetById()
        {
            // Initialize
            ValuesController controller = new ValuesController();

            // act
            string result = controller.Get("M_0001");

            // Assert
            Assert.AreEqual("M_0001", result);
        }

        [TestMethod]
        public void Post()
        {
            // Initialize
            ValuesController controller = new ValuesController();

            // act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Initialize
            ValuesController controller = new ValuesController();

            // act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Initialize
            ValuesController controller = new ValuesController();

            // act
            controller.Delete("M_0001");

            // Assert
        }
    }
}
