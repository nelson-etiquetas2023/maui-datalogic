
using Datalogic.Models;

namespace Datalogic.Services
{
    public interface IProductService
    {
        List<Product> GetProductsAsync();
        void AddProducts(Product producto);
    }
}
