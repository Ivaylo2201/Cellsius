namespace Core.Entities;

public class Model
{
    public int Id { get; set; }
    public required string ModelName { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = [];
}