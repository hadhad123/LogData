using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class LogRepository: ILogRepository 
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

        public PagedResult<LogDataDTO> GetAll(FilterObject<Log>FilterObject)
        {
           PagedResult<LogDataDTO> Paging = new PagedResult<LogDataDTO>();
            IEnumerable<LogDataDTO> Logs = DbContext.Logs.Include("LogType")
                  .Where(l => (l.LogMessage.Contains(FilterObject.SearchObject.LogMessage) || string.IsNullOrEmpty(FilterObject.SearchObject.LogMessage))
                  && (l.LogTypeID == FilterObject.SearchObject.LogTypeID || FilterObject.SearchObject.LogTypeID == 0))
                  .Select(x => new LogDataDTO {
                      LogID = x.LogID ,
                      LogMessage = x.LogMessage,
                      CreationDateTime = x.CreationDateTime,
                      LogTypeID = x.LogTypeID,
                      LogTypeName = x.LogType.LogName
                  });
          
           Paging.Results = Logs.Skip(FilterObject.PageSize * FilterObject.PageNumber).Take(FilterObject.PageSize).ToList();
           Paging.TotalNumOfRecords = Logs.Count();

            return Paging;
        }

        public Log GetLogByID(int ID)
        {
            Log Log = DbContext.Logs.Where(l => l.LogID == ID).Include("LogType").FirstOrDefault();
            return Log;
        }

    }
}
