using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly DBEntities DbContext;
        public LogRepository()
        {
            this.DbContext = new DBEntities();
        }

        /* saves Log to DB */
        public void AddLog(Log Data)
        {
            Data.CreationDateTime = DateTime.Now;
            DbContext.Logs.Add(Data);
            DbContext.Commit();
        }

        /* returns all logged data */
        public List<Log> GetLoggedData()
        {
            List<Log> AllLogs = DbContext.Logs.ToList();
            return AllLogs;
        }
    }
}
