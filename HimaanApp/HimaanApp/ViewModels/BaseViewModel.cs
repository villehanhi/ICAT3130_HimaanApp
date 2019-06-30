using System.ComponentModel;

namespace HimaanApp.ViewModels
{
    // PropertyChanged.Fody will take care of boiler plate code ralted to INotifyPropertyChanged
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { get; protected set; }
    }
}
