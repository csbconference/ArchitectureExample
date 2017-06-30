using ArchExample.Config;
using Autofac;

namespace ArchExample.Tests
{
    public class ArchExampleTestContext
    {
        public static IContainer AutofacContainer { get; private set; }

        static ArchExampleTestContext()
        {
            log4net.Config.XmlConfigurator.Configure();
            var builder = new ContainerBuilder();
            AutofacConfigurator.Configure(builder);
            AutofacContainer = builder.Build();
        }
    }
}
