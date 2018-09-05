using Autofac;
using Autofac.Integration.WebApi;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace LogDataWebAPI
{
    public class AutofacWebapiConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF Context
            builder.RegisterType<DBEntities>()
                   .As<DbContext>()
                   .InstancePerRequest();

            // Repositories
            builder.RegisterType<LogRepository>()
                .As<ILogRepository>().InstancePerRequest();

            // Services
            builder.RegisterType<LogService>()
                .As<ILogService>()
                .InstancePerRequest();


            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}