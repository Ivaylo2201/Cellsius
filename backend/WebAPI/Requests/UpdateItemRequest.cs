namespace WebAPI.Requests;

public record UpdateItemRequest
{
    public required int Quantity { get; init; }
}