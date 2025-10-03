namespace Application.DTOs.Order;

public record CreateOrderDto
{
    public required int UserId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}