using Application.DTOs.Item;

namespace Application.DTOs.Order;

public record GetOrderDto
{
    public required int Id { get; init; }
    public required ICollection<GetItemDto> Items { get; init; }
    public required double Total { get; init; }
    public required DateTime CreatedAt { get; init; }
}