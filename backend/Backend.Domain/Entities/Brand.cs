namespace Backend.Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Phone> Phones { get; set; } = [];
    public List<Model> Models { get; set; } = [];
}