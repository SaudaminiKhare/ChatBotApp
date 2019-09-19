using ChatBotDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectMonitorContractsLib
{
    public interface ISelectMonitor
    {
        Question FindQuestion(int ID);
        List<string> FindRequiredProduct(string[] responses);
        string[] RetrieveQuestionWithOptions(Question question);
    }
}
