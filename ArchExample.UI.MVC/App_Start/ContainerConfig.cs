using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI;
using ArchExample.Config;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace ArchExample.UI.MVC
{
    public partial class ContainerConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            RegisterDependencyMappingDefaults(builder);

            AutofacConfigurator.Configure(builder);

            var container = builder.Build();

            // Set Up MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterDependencyMappingDefaults(ContainerBuilder builder)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(IStateManager));
            var webAssembly = Assembly.GetAssembly(typeof(MvcApplication));

            builder.RegisterAssemblyTypes(coreAssembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(webAssembly);
            builder.RegisterModule(new AutofacWebTypesModule());
        }
    }
}