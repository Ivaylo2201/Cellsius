using Backend.Application.DTOs.Item;
using Backend.Application.DTOs.Shipping;

namespace Backend.Application.DTOs.Order;

public record GetOrderDto
{
    public required Guid Id { get; init; }
    public required decimal Total { get; init; }
    public required IEnumerable<GetItemDto> Items { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required GetShippingDto Shipping { get; init; }
}