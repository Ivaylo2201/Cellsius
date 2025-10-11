namespace Backend.Domain.Entities;

public class Model
{
    public int Id { get; init; }
    public required string ModelName { get; init; }
    public int BrandId { get; init; }
    public Brand Brand { get; init; } = null!;
}