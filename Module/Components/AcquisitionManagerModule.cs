using Autofac;
using SAT.Acqisition.Manager;
using SAT.Interface;

namespace SAT.Modules.Components
{
    public class AcquisitionManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AcquisitionManager>().As<IAcquisitionManager>().SingleInstance();
        }
    }
}