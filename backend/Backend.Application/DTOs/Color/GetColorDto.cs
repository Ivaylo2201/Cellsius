namespace Backend.Application.DTOs.Color;

public record GetColorDto
{
    public required int Id { get; init; }
    public required string ColorName { get; init; }
};