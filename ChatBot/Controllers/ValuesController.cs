using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatBot.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "M_0001", "M_0002", "M_0003", "M_0004", "M_0005", "M_0006", "M_0007", "M_0008", "M_0009", "M_0010" };
        }

        // GET api/values/M_0001
        public string Get(string id)
        {
            return "M_0001";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/M_0001
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/M_0001
        public void Delete(string id)
        {
        }
    }
}
