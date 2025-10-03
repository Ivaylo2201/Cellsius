namespace Application.DTOs.Review;

public record CreateReviewDto
{
    public required int Rating { get; init; }
    public required string? Comment { get; init; }
    public required Guid ProductId { get; init; }
    public required int UserId { get; init; }
}