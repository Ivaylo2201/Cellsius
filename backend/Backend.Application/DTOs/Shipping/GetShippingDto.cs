namespace Backend.Application.DTOs.Shipping;

public record GetShippingDto
{
    public required string Type { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
};