namespace Application.DTOs.User;

public record UpdateUserDto
{
    public required Core.Entities.User User { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Password { get; init; }
}