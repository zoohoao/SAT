using SAT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAT.StartBoot.Boot
{
    internal class StartBootViewModel
    {
        private readonly IAcquisitionManager _acquisitionManager;
        private readonly IMotionManager _motionManager;

        public StartBootViewModel(IAcquisitionManager acquisitionManager, IMotionManager motionManager)
        {
            _acquisitionManager = acquisitionManager;
            _motionManager = motionManager;
            StartSystemCommand = new RelayCommand(StartSystem);
        }

        public ICommand StartSystemCommand { get; }

        public void StartSystem()
        {
            MessageBox.Show("IOC DI.");
            Console.WriteLine("System starting...");
        }
    }
}