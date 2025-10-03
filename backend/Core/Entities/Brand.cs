namespace Core.Entities;

public class Brand
{
    public int Id { get; init; }
    public required string BrandName { get; init; }
    public ICollection<Product> Products { get; init; } = [];
    public ICollection<Model> Models { get; init; } = [];
}