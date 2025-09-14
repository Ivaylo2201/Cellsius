namespace Backend.Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    public required string BrandName { get; set; }
    
    public ICollection<Phone> Phones { get; set; } = [];
    public ICollection<Model> Models { get; set; } = [];
} 