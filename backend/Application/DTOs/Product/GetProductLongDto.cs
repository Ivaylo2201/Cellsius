using Application.DTOs.Review;

namespace Application.DTOs.Product;

public record GetProductLongDto : GetProductShortDto
{
    public required string Description { get; init; }
    public required string CategoryName { get; init; }
    public required List<GetReviewDto> Reviews { get; init; }
}