using ChatBotDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace ChatBot.Controllers
{
    public class PatientMonitorController : ApiController
    {
        public IEnumerable<PatientMonitor> Get()
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                return entities.PatientMonitors.ToList();
            }
        }

        readonly UnityContainer _con = new UnityContainer();
        private MonitorCrudContractsLib.IMonitorCrud _monitorCrud;

        /// <summary>
        ///Deals with the products in the ChatbotTabledata 
        /// </summary>
        public PatientMonitorController()
        {
            _con.RegisterType<MonitorCrudContractsLib.IMonitorCrud, MonitorCrudLib.MonitorCrud>();
        }

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="data">Enter parameters for Product</param>
        /// <returns>An HTTP Status code that indicates the outcome of the operation.</returns>

        [Route("api/product/addProduct")]
        public HttpResponseMessage Post([FromBody] PatientMonitor data)
        {
            _monitorCrud = _con.Resolve<MonitorCrudContractsLib.IMonitorCrud>();
            var entity = _monitorCrud.AddProductintoDatabase(data);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Device is not added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Product has been added successfully ");
            }
        }

        /// <summary>
        /// Delete a product by it's name
        /// </summary>
        /// <param name="ProductName">Name of the Product Class</param>
        /// <returns>An HTTP Status code that indicates the outcome of the operation with a message.</returns>
        [Route("api/product/deleteProduct/{model}")]
        public HttpResponseMessage Delete(string model)
        {
            _monitorCrud = _con.Resolve<MonitorCrudContractsLib.IMonitorCrud>();
            bool entity = _monitorCrud.DeleteProductFromDatabase(model);
            if (!entity)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product is not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Product has been removed successfully ");
            }
        }
    }  
}
