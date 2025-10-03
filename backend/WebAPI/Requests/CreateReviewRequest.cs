namespace WebAPI.Requests;

public record CreateReviewRequest
{
    public required int Rating { get; init; }
    public string? Comment { get; init; }
    public required Guid ProductId { get; init; }
};