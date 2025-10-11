namespace Backend.Domain.Entities;

public class User
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; init; } = null!;
    public ICollection<Order> Orders { get; init; } = [];
}