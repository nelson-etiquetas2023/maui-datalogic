using Datalogic.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Datalogic.Services
{
    public class MonkeyService
    {
        readonly HttpClient httpClient;
        public List<Monkey>? monkeyList = [];

        public MonkeyService()
        {
            httpClient = new HttpClient();
        }

        
        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList?.Count > 0)
                return monkeyList;

            var url = "https://montemagno.com/monkeys.json";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) 
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            return monkeyList!;
        }

        public int CalculateMonkey() 
        {
            if (monkeyList == null || monkeyList.Count == 0)
                return 0;

            return monkeyList.Count;
        }

        public ObservableCollection<Monkey> SearchMonkeys(string filterText,ObservableCollection<Monkey> lista) 
        {
            var monkeyListFiltered = new ObservableCollection<Monkey>();

            if (lista == null || lista.Count <= 0 || string.IsNullOrEmpty(filterText))
                return monkeyListFiltered;

            monkeyListFiltered =  [.. lista.Where(x => x.Name.Contains(filterText, StringComparison.CurrentCultureIgnoreCase ))];

            return monkeyListFiltered;

        }        
    }
}
