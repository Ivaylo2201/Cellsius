using Core.Enums;

namespace Core.Entities;

public class Shipping
{
    public int Id { get; init; }
    public required ShippingType Type { get; set; }
    public required int Cost { get; set; }
    public required int Days { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}