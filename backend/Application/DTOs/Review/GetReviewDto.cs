namespace Application.DTOs.Review;

public record GetReviewDto
{
    public required int Rating { get; init; }
    public required string? Comment { get; init; }
    public required string Username { get; init; }
    public required DateTime CreatedAt { get; init; }
}