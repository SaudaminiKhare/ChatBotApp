using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatBotDataAccess;


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

        public PatientMonitor Get(string m_id)
        {
            using(ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                return entities.PatientMonitors.FirstOrDefault(p => p.Model == m_id);
            }
        }
    }
}
