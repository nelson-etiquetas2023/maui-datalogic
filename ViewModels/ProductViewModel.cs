using CommunityToolkit.Mvvm.ComponentModel;
using Datalogic.Models;
using Datalogic.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Datalogic.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        private IProductService ProductService { get; set; }

        public ICommand AddProducts { get; } = null!;

        public ProductViewModel(IProductService ProductService)
        {
            Products = new ObservableCollection<Product>();
            isRefreshing = false;
            searchText = string.Empty;
            //var productList = ProductService.GetProductsAsync();
            //Products = new ObservableCollection<Product>(productList);
            this.ProductService = ProductService;
            AddProducts = new Command(OnAddProducts);
           
        }

        public void OnAddProducts() 
        {
            ProductService.AddProducts(new Product { ProductId=4, ProductName="Portatil lenovo thinkpad carbon t540"});
        }
    }
}
