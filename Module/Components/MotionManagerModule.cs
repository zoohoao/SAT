using Autofac;
using SAT.Interface;
using SAT.Motion.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Modules.Components
{
    public class MotionManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MotionManager>().As<IMotionManager>().SingleInstance();
        }
    }
}