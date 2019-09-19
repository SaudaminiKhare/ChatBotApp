using ChatBotDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCrudContractsLib
{
   
        public interface IMonitorCrud
        {
            PatientMonitor AddProductintoDatabase(PatientMonitor PatientMonitor);
            bool DeleteProductFromDatabase(string model);
            List<PatientMonitor> FindAllProducts();
        }

    
}
