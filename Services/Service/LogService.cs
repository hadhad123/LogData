using Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogService :ILogService
    {
        private readonly ILogRepository LogRepository;

        public LogService(ILogRepository LogRepository)
        {
            this.LogRepository = LogRepository;
        }

        /* returns a list of all logged Data */
        public List<Log> GetLoggedData()
        {
            return LogRepository.GetLoggedData();
        }

        /* tries to log result if fails then logs exception */
        public LogType LogData(Log Data)
        {
            LogType Type = new LogType();
            Data.CreationDateTime = DateTime.Now;
            try //logs result 
            {
               // Data.LogTypeID = 1;
                LogRepository.AddLog(Data);

                Type.LogName = "Result";
            }
            catch(Exception ex) // logs exception
            {
                Data.LogTypeID = 2;
                Data.LogMessage = ex.Message;
                LogRepository.AddLog(Data);

                Type.LogName = "Exception";
            }
            return Type;
        }
    }
}
