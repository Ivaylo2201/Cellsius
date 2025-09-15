namespace Backend.Application.DTOs.Phone;

public record GetPhoneLongDto
{
    public required Guid Id { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required string ColorName { get; init; }
    public required int DiscountPercentage { get; init; }
    public required PriceDto Price { get; init; }
    public required int Memory { get; init; }
    public required string ImagePath { get; init; }
};