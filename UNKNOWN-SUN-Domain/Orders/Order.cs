namespace Unknown_Sun_Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
