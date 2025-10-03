namespace WebAPI.Requests;

public record AddItemToCartRequest
{
    public required Guid ProductId { get; init; }
    public int Quantity { get; init; } = 1;
}