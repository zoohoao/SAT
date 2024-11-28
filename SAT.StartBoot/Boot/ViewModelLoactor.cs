using Autofac;
using SAT.Modules.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.StartBoot.Boot
{
    internal class ViewModelLoactor
    {
        private IContainer _container;
        public StartBootViewModel StartBootMode { get; }

        public ViewModelLoactor()
        {
            var builder = new ContainerBuilder();

            // 注册组件
            builder.RegisterModule<AcquisitionManagerModule>();
            builder.RegisterModule<MotionManagerModule>();
            builder.RegisterModule<PulseManagerModule>();
            //// 注册 ViewModel
            builder.RegisterType<StartBootViewModel>();
            _container = builder.Build();

            StartBootMode = _container.Resolve<StartBootViewModel>();
        }
    }
}