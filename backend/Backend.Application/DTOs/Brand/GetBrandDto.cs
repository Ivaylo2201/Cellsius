namespace Backend.Application.DTOs.Brand;

public record GetBrandDto
{
    public required int Id { get; init; }
    public required string BrandName { get; init; }
    public required int PhonesCount { get; init; }
};