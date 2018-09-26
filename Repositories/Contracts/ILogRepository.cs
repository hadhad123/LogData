using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ILogRepository 
    {
        void AddLog(Log Data);
        List<Log> GetLoggedData();
        PagedResult<LogDataDTO> GetAll(FilterObject<Log> FilterObject);
        Log GetLogByID(int ID);
    }
}
