using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace SAT.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _text;

        public string Text
        {
            get => _text;
            set => Set(ref _text, value); // 自动触发 PropertyChanged 事件
        }

        public MainViewModel()
        {
            Text = "Hello, MVVM Light!";
            UpdateTextCommand = new RelayCommand(UpdateText);
        }

        public ICommand UpdateTextCommand { get; }

        private void UpdateText()
        {
            Text = "You clicked the button!";
        }
    }
}