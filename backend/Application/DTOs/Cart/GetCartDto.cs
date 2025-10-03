using Application.DTOs.Item;

namespace Application.DTOs.Cart;

public record GetCartDto
{
   public required int Id { get; init; }
   public required double Total { get; init; }
   public required List<GetItemDto> Items { get; init; }
};