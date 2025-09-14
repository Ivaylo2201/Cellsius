namespace Backend.Domain.Entities;

public class Shipping
{
    public int Id { get; set; }
    public required string Type { get; set; }
    public required int Cost { get; set; }
    public required int Days { get; set; }
    
    public ICollection<Order> Orders { get; set; } = [];
}