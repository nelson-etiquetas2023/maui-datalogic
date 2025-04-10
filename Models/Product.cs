
namespace Datalogic.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Ubication { get; set; } = null!;
        public int Quantity { get; set; }
        public string Codebar { get; set; } = null!;
    }
}
