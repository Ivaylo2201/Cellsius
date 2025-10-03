namespace WebAPI.Requests;

public record CreateUserRequest
{
    public required string Username { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Password { get; init; }
    public required string PasswordConfirmation { get; init; }
};