using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            HasKey(l => l.LogID);
            Property(l => l.LogMessage).IsRequired();
            Property(l => l.LogTypeID).IsRequired();
        }
    }
}
