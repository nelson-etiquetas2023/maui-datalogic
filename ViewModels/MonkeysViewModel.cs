using CommunityToolkit.Mvvm.Input;
using Datalogic.Models;
using Datalogic.Services;
using Datalogic.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Datalogic.ViewModels
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        readonly MonkeyService monkeyService;
        public ObservableCollection<Monkey> Monkeys { get; } = [];

        public MonkeysViewModel(MonkeyService monkeyService)
        {
            Title = "Monkey Finder [Datalogic]";
            this.monkeyService = monkeyService;
          
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Monkey monkey) 
        {
            if (monkey is null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                { "Monkey", monkey }
            });
        }

        [RelayCommand]
        async Task GetMonkeysAsync() 
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();

                if(Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);


            }
            catch (Exception ex)
            {
               Debug.WriteLine($"Unable to get monkeys: {ex}");
               await Shell.Current.DisplayAlert("Error", "Unable to get monkeys", "OK");
            }
            finally 
            {
                IsBusy = false;
            }
            
        }
    }
} 
