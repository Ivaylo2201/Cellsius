using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Shipping
{
    public int Id { get; init; }
    public required ShippingType ShippingType { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
}