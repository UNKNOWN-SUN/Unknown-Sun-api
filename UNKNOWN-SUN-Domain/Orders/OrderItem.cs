using Unknown_Sun_Domain.Catalog;

namespace Unknown_Sun_Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public int Quantity { get; set; }
    }
}
