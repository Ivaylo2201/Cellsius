namespace Backend.Domain.Entities;

public class Color
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Phone> Phones { get; set; } = [];
}