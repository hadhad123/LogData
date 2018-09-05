using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LogType
    {
        public LogType()
        {
            Logs = new List<Log>();
        }
        public int LogTypeID { get; set; }
        public string LogName { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
