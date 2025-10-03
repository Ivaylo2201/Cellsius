namespace Application.DTOs.Item;

using Product = Core.Entities.Product;
using Cart = Core.Entities.Cart;

public record CreateItemDto
{
    public required Product Product { get; init; }
    public required Cart Cart { get; init; }
    public required int Quantity { get; init; }
}