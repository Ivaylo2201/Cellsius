namespace Backend.Domain.Entities;

public class Color
{
    public int Id { get; set; }
    public required string ColorName { get; set; }
    public ICollection<Phone> Phones { get; set; } = [];
}