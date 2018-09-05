using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class LogTypeConfiguration : EntityTypeConfiguration<LogType>
    {
        public LogTypeConfiguration()
        {
            HasKey(l => l.LogTypeID);
            Property(l => l.LogName).IsRequired();
        }
    }
}
