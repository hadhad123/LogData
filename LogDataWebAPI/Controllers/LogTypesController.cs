using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using Model.DTO;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogTypesController : ApiController
    {
        public readonly ILogTypeService _LogTypeService;
        public LogTypesController(ILogTypeService LogTypeService)
        {
            _LogTypeService = LogTypeService;
        }

        [HttpGet]
        public IHttpActionResult GetLogTypes()
        {
            List<LogType> LogTypes = _LogTypeService.GetLogTypes();
            return Ok(LogTypes);
        }

    }
}
