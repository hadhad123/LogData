namespace Data.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBEntities context)
        {
            //  This method will be called after migrating to the latest version

            List<LogType> LogTypes = new List<LogType>();
            LogType Results = new LogType()
            {
                LogTypeID = 1,
                LogName = "Result"
            };
            LogType Exception = new LogType()
            {
                LogTypeID = 2,
                LogName = "Exception"
            };
            LogTypes.Add(Results);
            LogTypes.Add(Exception);

            foreach (LogType type in LogTypes)
            {
                LogType TypeExists = context.LogTypes.FirstOrDefault(l => l.LogName == type.LogName);
                if (TypeExists == null)
                    context.LogTypes.Add(type);
            }
            context.Commit();

        }
    }
}
