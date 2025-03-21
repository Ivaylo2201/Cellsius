namespace Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required decimal Total { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }

        public int ShippingId { get; set; }
        public required Shipping Shipping { get; set; }

        public List<Item> Items { get; set; } = [];
    }
}
