namespace Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Item> Items { get; set; } = [];
    }
}
