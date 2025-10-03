namespace Core.Entities;

public class Review
{
    public int Id { get; init; }
    public required int Rating { get; init; }
    public string? Comment { get; init; }
    public Guid ProductId { get; init; }
    public Product Product { get; set; } = null!;
    public int UserId { get; init; }
    public User User { get; set; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}