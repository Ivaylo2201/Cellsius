namespace Backend.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = [];
}