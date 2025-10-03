namespace Application.DTOs.Product;

public record GetProductShortDto
{
    public required Guid Id { get; init; }
    public required string ProductName { get; init; }
    public required double InitialPrice { get; init; }
    public required double Price { get; init; }
    public required int Rating { get; init; }
    public required int DiscountPercentage { get; init; }
    public required string ImageUrl { get; init; }
}