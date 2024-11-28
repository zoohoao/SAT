using Autofac;
using SAT.Helps.Handler;
using SAT.Helps.SsytemOperation;
using SAT.Interface.Common;

namespace SAT.Modules.Components
{
    public class HelpsHandlersManager : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelpsHandlers>().As<IHelpsHandlers>().InstancePerLifetimeScope();

            builder.RegisterType<ConfigManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
            builder.RegisterType<CryptoManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
            builder.RegisterType<FileManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
            builder.RegisterType<ResourceManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
            builder.RegisterType<SystemAPIManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
            builder.RegisterType<SystemInfoManager>().InstancePerMatchingLifetimeScope("HelpsHandlersScope");
        }
    }
}