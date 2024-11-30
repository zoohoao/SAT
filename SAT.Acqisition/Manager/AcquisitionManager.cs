using SAT.Interface;
using SAT.Interface.Core;

namespace SAT.Acqisition.Manager
{
    public class AcquisitionManager : BaseManager, IAcquisitionManager
    {
        private readonly IMotionManager _motionManager;
        private readonly IPulseManager _pulseManager;

        public AcquisitionManager(IMotionManager motionManager, IPulseManager pulseManager)
        {
            _motionManager = motionManager;
            _pulseManager = pulseManager;
        }

        public void Collect()
        {
            System.Console.WriteLine("ACQ collect");
        }
    }
}