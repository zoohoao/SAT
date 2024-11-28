using Autofac;
using SAT.Helps.SsytemOperation;
using SAT.Interface.Common;

namespace SAT.Helps.Handler
{
    public class HelpsHandlers : IHelpsHandlers
    {
        private readonly ILifetimeScope _lifetimeScope;

        public HelpsHandlers(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope.BeginLifetimeScope("HelpsHandlersScope");
        }

        //public IConfigManager configManager => _lifetimeScope.Resolve<IConfigManager>();
        //public ICryptoManager cryptoManager => _lifetimeScope.Resolve<ICryptoManager>();
        //public IFileManager fileManager => _lifetimeScope.Resolve<IFileManager>();
        //public IResourceManager resourceManager => _lifetimeScope.Resolve<IResourceManager>();
        //public ISystemAPIManager systemAPIManager => _lifetimeScope.Resolve<ISystemAPIManager>();
        //public ISystemInfoManager systemInfoManager => _lifetimeScope.Resolve<ISystemInfoManager>();

        public object GetConfigManager()
        {
            return _lifetimeScope.Resolve<ConfigManager>();
        }

        public object GetCryptoManager()
        {
            return _lifetimeScope.Resolve<CryptoManager>();
        }

        public object GetFileManager()
        {
            return _lifetimeScope.Resolve<FileManager>();
        }

        public object GetResourceManager()
        {
            return _lifetimeScope.Resolve<ResourceManager>();
        }

        public object GetSystemAPIManager()
        {
            return _lifetimeScope.Resolve<SystemAPIManager>();
        }

        public object GetSystemInfoManager()
        {
            return _lifetimeScope.Resolve<SystemInfoManager>();
        }
    }
}