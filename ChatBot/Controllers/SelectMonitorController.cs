using ChatBotDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Unity;

namespace ChatBot.Controllers
{
    public class SelectMonitorController : ApiController
    {
        readonly UnityContainer _container = new UnityContainer();
        public SelectMonitorContractsLib.ISelectMonitor _selectMonitor;
        public SelectMonitorController()
        {
            _container.RegisterType<SelectMonitorContractsLib.ISelectMonitor, SelectMonitorLib.SelectMonitor>();
        }

        /// <summary>
        /// Gets the list of products based on the inputs of the user
        /// </summary>
        /// <param name="response1">Input of the user for the first question</param>
        /// <param name="response2">Input of the user for the second question</param>
        /// <param name="response3">Input of the user for the third question</param>
        /// <param name="response4">Input of the user for the fourth question</param>
        /// <param name="response5">Input of the user for the fifth question</param>
        /// <param name="response6">Input of the user for the sixth question</param>
        /// <returns>An HTTP Status code that indicates the outcome of the operation with a List of Product Names</returns>

        [Route("api/chat/{response1?}")]
        [Route("api/chat/{response1}/{response2?}")]
        [Route("api/chat/{response1}/{response2}/{response3?}")]
        [Route("api/chat/{response1}/{response2}/{response3}/{response4?}")]
        [Route("api/chat/{response1}/{response2}/{response3}/{response4}/{response5?}")]
        [Route("api/chat/{response1}/{response2}/{response3}/{response4}/{response5}/{response6?}")]
        public HttpResponseMessage GetProduct(string response1 = null, string response2 = null, string response3 = null, string response4 = null, string response5 = null, string response6 = null)
        {
            _selectMonitor = _container.Resolve<SelectMonitorContractsLib.ISelectMonitor>();
            String currentUrl = HttpContext.Current.Request.RawUrl;
            string[] optionList = currentUrl.Split('/');
            ChatBotDBEntities entities = new ChatBotDBEntities();
            int slashCounter = optionList.Length;
            int noofQuestions = entities.Questions.Count();
            if (slashCounter - 3 == noofQuestions)
            {
                var entity = _selectMonitor.FindRequiredProduct(optionList);
                if (entity.Count() == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            else
            {
                Question next;
                next = _selectMonitor.FindQuestion(slashCounter - 2);
                return Request.CreateResponse(HttpStatusCode.OK, _selectMonitor.RetrieveQuestionWithOptions(next));
            }
        }
    }
}
