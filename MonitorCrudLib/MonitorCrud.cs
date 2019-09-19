using ChatBotDataAccess;
using MonitorCrudContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCrudLib
{

    public class MonitorCrud : IMonitorCrud
    {
        public PatientMonitor AddProductintoDatabase(PatientMonitor PatientMonitor)
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                var entity = entities.PatientMonitors.Add(PatientMonitor);
                entities.SaveChanges();
                return entity;
            }
        }

        public bool DeleteProductFromDatabase(string model)
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                bool deleteCheck = false;
                var entity = entities.PatientMonitors.FirstOrDefault(e => e.Model == model);
                if (entity != null)
                {
                    entities.PatientMonitors.Remove(entity);
                    entities.SaveChanges();
                    deleteCheck = true;
                }
                return deleteCheck;
            }
            
        }

        public List<PatientMonitor> FindAllProducts()
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                return entities.PatientMonitors.ToList();
            }
        }

        //public PatientMonitor updateProductintoDatabase(PatientMonitor data, string model)
        //{
        //    using (ChatBotDBEntities entities = new ChatBotDBEntities())
        //    {
        //        var entity = entities.PatientMonitors.FirstOrDefault(e => e.Model == model);
        //        if (entity != null)
        //        {
        //            entity.ProductName = data.ProductName;
        //            entity.Series = data.Series;
        //            entity.Modular = data.Modular;
        //            entity.Portability = data.Portability;
        //            entity.QuickAlerts = data.QuickAlerts;
        //            entity.DisplaySize = data.DisplaySize;
        //            entity.Foetal = data.Foetal;
        //            entity.Touch = data.Touch;
        //            entities.SaveChanges();
        //        }
        //        return entity;
        //    }
        //}
    }
}
