namespace Backend.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required decimal Total { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int ShippingId { get; set; }
    public Shipping Shipping { get; set; } = null!;

    public List<Item> Items { get; set; } = [];
}