using Autofac;
using SAT.Interface;
using SAT.Pulser.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Modules.Components
{
    public class PulseManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PulseManager>().As<IPulseManager>().SingleInstance();
        }
    }
}