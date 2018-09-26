using Model;
using Model.DTO;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogTypeService : ILogTypeService
    {
        private readonly ILogTypeRepository LogTypeRepository;

        public LogTypeService(ILogTypeRepository LogTypeRepository)
        {
            this.LogTypeRepository = LogTypeRepository;
        }

        /* returns a list of all LogTypeged Data */
        public List<LogType> GetLogTypes()
        {
            return LogTypeRepository.GetLogTypes();
        }

    }
}
