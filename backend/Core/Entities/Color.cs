namespace Core.Entities;

public class Color
{
    public int Id { get; set; }
    public required string ColorName { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}