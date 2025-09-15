namespace Backend.Application.DTOs.Phone;

public record PriceDto
{
    public required decimal Initial { get; init; }
    public required decimal Discounted { get; init; }
};