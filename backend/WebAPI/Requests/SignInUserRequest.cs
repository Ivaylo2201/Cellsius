namespace WebAPI.Requests;

public record SignInUserRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
};