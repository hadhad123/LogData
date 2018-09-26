using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILogService
    {
        List<Log> GetLoggedData();
        LogType LogData(Log Data);
        PagedResult<LogDataDTO> GetAll(FilterObject<Log> FilterObject);
        Log GetLogByID(int ID);
    }
}
