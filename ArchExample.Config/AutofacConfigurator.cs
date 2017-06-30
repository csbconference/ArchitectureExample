using ArchExample.Common.Interfaces.Domain;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Repository;
using ArchExample.Common.Interfaces.Services;
using ArchExample.Domain;
using ArchExample.Logger;
using ArchExample.Mail;
using ArchExample.Repository;
using ArchExample.Services;
using Autofac;

namespace ArchExample.Config
{
    public class AutofacConfigurator
    {
        public static void Configure(ContainerBuilder builder)
        {
            // REPOSITORIES
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>();

            // DOMAINS
            builder.RegisterType<EmployeeDomain>().As<IEmployeeDomain>();
            builder.RegisterType<StoreDomain>().As<IStoreDomain>();

            // SERVICES
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<StoreService>().As<IStoreService>();

            // HELPERS
            builder.RegisterType<Log4NetLoggerHelper>().As<ILogHelper>();
            builder.RegisterType<MailHelper>().As<IMailHelper>();
        }
    }
}
