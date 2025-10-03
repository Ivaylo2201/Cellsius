namespace Core.Entities;

public class Category
{
    public int Id { get; init; }
    public required string CategoryName { get; init; }
    public ICollection<Product> Products { get; init; } = [];
}