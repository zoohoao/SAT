using SAT.Interface;

namespace SAT.Acqisition.Manager
{
    public class AcquisitionManager : IAcquisitionManager
    {
        private readonly IMotionManager _motionManager;
        private readonly IPulseManager _pulseManager;

        public AcquisitionManager(IMotionManager motionManager, IPulseManager pulseManager)
        {
            _motionManager = motionManager;
            _pulseManager = pulseManager;
        }
    }
}