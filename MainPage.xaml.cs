using Datalogic.ViewModels;
using Datalogic.Services;

namespace Datalogic
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MonkeysViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
