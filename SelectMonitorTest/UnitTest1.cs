using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using SelectMonitorLib;
using ChatBotDataAccess;
using SelectMonitorContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace SelectMonitorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string FeatureList = "F_001,F_002,F_005";
            List<string> DesiredFeatures = new List<string>();
            DesiredFeatures.Add("F_001");
            DesiredFeatures.Add("F_002");
            DesiredFeatures.Add("F_005");
            DesiredFeatures.Add("F_006");
            SelectMonitor monitorObj = new SelectMonitor();
            int result = monitorObj.FindScore(FeatureList, DesiredFeatures);
            Assert.AreEqual(3,result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string FeatureList = "F_001,F_003,F_005,F_006";
            List<string> DesiredFeatures = new List<string>();
            DesiredFeatures.Add("F_001");
            DesiredFeatures.Add("F_002");
            DesiredFeatures.Add("F_005");
            DesiredFeatures.Add("F_006");
            SelectMonitor monitorObj = new SelectMonitor();
            int result = monitorObj.FindScore(FeatureList, DesiredFeatures);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] response;
            response = new string[9] {"https://localhost:44342","api","chat", "Yes", "Yes", "No", "Yes", "No", "Yes"};
            List<string> expected = new List<string>();
            expected.Add("M_0001");
            expected.Add("M_0009");
            expected.Add("M_0010");
            SelectMonitor monitorObj = new SelectMonitor();
            List<String> result = new List<String>();
            result = monitorObj.FindRequiredProduct(response);
            int len = expected.Count();
            for(int index = 0; index<len; index++)
            {
                Assert.AreEqual(expected.ElementAt(index), result.ElementAt(index));
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] response;
            response = new string[9] { "https://localhost:44342", "api", "chat", "Yes", "no", "yes", "Yes", "No", "Yes" };
            List<string> expected = new List<string>();
            expected.Add("M_0010");
            SelectMonitor monitorObj = new SelectMonitor();
            List<String> result = new List<String>();
            result = monitorObj.FindRequiredProduct(response);
            int len = expected.Count();
            for (int index = 0; index < len; index++)
            {
                Assert.AreEqual(expected.ElementAt(index), result.ElementAt(index));
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            int q_id;
            q_id = 4;
            ChatBotDBEntities entities = new ChatBotDBEntities();
            Question first_question = entities.Questions.Find(Id);
            SelectMonitor monitorObj = new SelectMonitor();
            result = monitorObj.FindRequiredProduct(response);
            int len = expected.Count();
            for (int index = 0; index < len; index++)
            {
                Assert.AreEqual(expected.ElementAt(index), result.ElementAt(index));
            }
        }
    }
}
