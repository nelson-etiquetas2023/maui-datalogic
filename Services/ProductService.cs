
using Datalogic.Models;
using System.Reflection.Metadata;

namespace Datalogic.Services
{
    public class ProductService : IProductService
    {
        public void AddProducts(Product producto)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsAsync()
        {
            List<Product> products =
            [
                new Product { ProductId=1,ProductName="Impresora Zebra ZD-220" },
                new Product { ProductId=2,ProductName="Iphone 14 Pro Max" },
                new Product { ProductId=3,ProductName="Celular Tecno Spark" }
            ];

            return products;
        }

    }
}
