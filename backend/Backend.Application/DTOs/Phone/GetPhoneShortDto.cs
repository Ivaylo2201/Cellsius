namespace Backend.Application.DTOs.Phone;

public record GetPhoneShortDto
{
    public required Guid Id { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required string ImagePath { get; init; }
};