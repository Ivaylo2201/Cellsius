namespace Core.Entities;

public class Cart
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public double Total { get; init; }
    public ICollection<Item> Items { get; init; } = [];
}