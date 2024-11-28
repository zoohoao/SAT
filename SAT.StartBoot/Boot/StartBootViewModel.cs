using SAT.Core.Common;
using SAT.Helps.SsytemOperation;
using SAT.Interface;
using SAT.Interface.Common;
using System.Windows.Input;

namespace SAT.StartBoot.Boot
{
    internal class StartBootViewModel : SATLog
    {
        private readonly IAcquisitionManager _acquisitionManager;
        private readonly IMotionManager _motionManager;
        private readonly IHelpsHandlers _helpsHandlers;

        public StartBootViewModel(IAcquisitionManager acquisitionManager, IMotionManager motionManager,
            IHelpsHandlers helpsHandlers)
        {
            _helpsHandlers = helpsHandlers;
            _acquisitionManager = acquisitionManager;
            _motionManager = motionManager;
            StartSystemCommand = new RelayCommand(StartSystem);
        }

        public ICommand StartSystemCommand { get; }

        public void StartSystem()
        {
            ConfigManager a = (ConfigManager)_helpsHandlers.GetConfigManager();
            a.ConfigSetting();
            Trace_Log("dfdfdfdf");
            _acquisitionManager.Collect();
        }
    }
}