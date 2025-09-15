namespace Backend.Application.DTOs.Order;

public record CreateOrderDto
{
    public required int UserId;
    public required int ShippingId { get; init; }
};