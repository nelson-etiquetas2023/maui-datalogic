using CommunityToolkit.Mvvm.ComponentModel;

namespace Datalogic.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            Title = "";
        }
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        private string title;

        public bool IsNotBusy => !IsBusy;




    }
}
