namespace Core.Entities;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string ProductName { get; init; }
    public required double InitialPrice { get; init; }
    public int DiscountPercentage { get; init; }
    public required string ImageUrl { get; init; }
    public required string Description { get; init; }
    public int CategoryId { get; init; }
    public Category Category { get; init; } = null!;
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<Item> Items { get; init; } = [];

    public double Price => InitialPrice * (1 - DiscountPercentage / 100.0);
}