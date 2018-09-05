using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Log
    {
        public Log()
        {
           
        }
        public int LogID { get; set; }
        public string LogMessage { get; set; }
        public int LogTypeID { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual LogType LogType { get; set; }
    }
}
