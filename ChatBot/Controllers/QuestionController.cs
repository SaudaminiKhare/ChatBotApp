using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatBotDataAccess;

namespace ChatBot.Controllers
{
    public class QuestionController : ApiController
    {
        public IEnumerable<Question> Get()
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                return entities.Questions.ToList();
            }
        }

        [Route ("api/Question/{q_id}")]
        public Question Get(string q_id)
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                return entities.Questions.FirstOrDefault(p => (p.Question_ID.Equals(q_id)));
            }
        }
    }
}
