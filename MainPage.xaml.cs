using Datalogic.ViewModels;
using Datalogic.Services;

namespace Datalogic
{
    public partial class MainPage : ContentPage
    {
        bool firstTime = true;
        public MonkeysViewModel vm { get; set; }
        public MainPage(MonkeysViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            vm = viewModel;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!firstTime && string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                await SearchBarAll();
            }
            else
            {
                firstTime = false;
            }
        }

        private async Task SearchBarAll() 
        {
            await vm.GetMonkeysAsync();
        }
    }
}


