using Backend.Application.DTOs.Item;

namespace Backend.Application.DTOs.Cart;

public record GetCartDto
{
    public required IEnumerable<GetItemDto> Items { get; init; }
    public required decimal Subtotal { get; init; }
};