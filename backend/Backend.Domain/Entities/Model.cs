namespace Backend.Domain.Entities;

public class Model
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;

    public List<Phone> Phones { get; set; } = [];
}