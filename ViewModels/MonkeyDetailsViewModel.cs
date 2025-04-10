
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Datalogic.Models;

namespace Datalogic.ViewModels
{
    [QueryProperty(nameof(Monkey), "Monkey")]
    public partial class MonkeyDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Monkey monkey;

        public MonkeyDetailsViewModel()
        {
            
        }
    }
}
