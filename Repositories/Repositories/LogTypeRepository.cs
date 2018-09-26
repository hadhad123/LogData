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
    public class LogTypeRepository : ILogTypeRepository
    {
        private readonly DBEntities DbContext;

        public LogTypeRepository()
        {
            this.DbContext = new DBEntities();
        }

        /* returns all LogTypeged data */
        public List<LogType> GetLogTypes()
        {
            List<LogType> AllLogTypes = DbContext.LogTypes.ToList();
            return AllLogTypes;
        }

    }
}
