using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;

namespace WebAPI.Controllers
{
    public class LogsController : ApiController
    {
        public readonly ILogService _LogService;
        public LogsController(ILogService LogService) // inject Interface NOT CLASS!!!!!!
        {
            _LogService = LogService;
        }

        [HttpGet]
        public IHttpActionResult GetLogs()
        {
            List<Log> Logs = _LogService.GetLoggedData();
            return Ok(Logs);
        }

        [HttpPost]
        [Route("api/Logs/LogData")]
        public IHttpActionResult LogData(Log Data)
        {
            LogType Type = _LogService.LogData(Data);
            return Ok(Type);
        }
    }
}
