namespace Backend.Domain.Entities;

public class Order
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public int ShippingId { get; init; }
    public required Shipping Shipping { get; init; }
    public ICollection<Item> Items { get; init; } = [];
}