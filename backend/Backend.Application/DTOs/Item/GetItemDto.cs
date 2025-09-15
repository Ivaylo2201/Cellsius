using Backend.Application.DTOs.Phone;

namespace Backend.Application.DTOs.Item;

public record GetItemDto
{
    public required int Id { get; init; }
    public required int Quantity { get; init; }
    public required GetPhoneShortDto Phone { get; init; }
    public required decimal Price { get; init; }
}