namespace Application.DTOs.Item;

using Item = Core.Entities.Item;

public record UpdateItemDto
{
    public required Item Item { get; init; }
    public required int Quantity { get; init; }
}
