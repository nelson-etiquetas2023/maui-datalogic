using CommunityToolkit.Mvvm.ComponentModel;
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

        [ObservableProperty]
        private int totalCount = 0;

        [ObservableProperty]
        private string? filterText = string.Empty;

        public MonkeysViewModel(MonkeyService monkeyService)
        {
            Title = "Monkey Finder [Datalogic]";
            this.monkeyService = monkeyService;
        }

        [RelayCommand]
        public async Task OnSearchMonkeysAsync()
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                await Shell.Current.DisplayAlert("Error", "Filter text cannot be empty.", "OK");
                return;
            }

            if (Monkeys is null)
                return;

            // Clear the existing collection and add the filtered results instead of reassigning the property
            var filteredMonkeys = monkeyService.SearchMonkeys(FilterText, Monkeys);
            Monkeys.Clear();
            foreach (var monkey in filteredMonkeys)
            {
                Monkeys.Add(monkey);
            }

            var monkeysFilters = Monkeys.Count;
            TotalCount = monkeysFilters;
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
        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);

                OnCalculateMonkeys();
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

        public void OnCalculateMonkeys()
        {
            TotalCount = monkeyService.CalculateMonkey();
        }
    }
} 
