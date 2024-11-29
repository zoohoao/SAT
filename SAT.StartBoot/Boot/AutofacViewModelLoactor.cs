using Autofac;
using SAT.Modules.Components;

namespace SAT.StartBoot.Boot
{
    internal class AutofacViewModelLoactor
    {
        private IContainer _container;
        public StartBootViewModel StartBootMode { get; }

        public AutofacViewModelLoactor()
        {
            var builder = new ContainerBuilder();

            // 注册组件
            builder.RegisterModule<AcquisitionManagerModule>();
            builder.RegisterModule<MotionManagerModule>();
            builder.RegisterModule<PulseManagerModule>();
            builder.RegisterModule<HelpsHandlersManager>();
            //// 注册 ViewModel
            builder.RegisterType<StartBootViewModel>();
            _container = builder.Build();

            StartBootMode = _container.Resolve<StartBootViewModel>();
        }
    }
}