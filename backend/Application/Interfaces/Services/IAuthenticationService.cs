using Core.Entities;

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<(bool, User)> IsSignedUpAsync(string username, string password);
    Task<bool> IsUsernameTakenAsync(string username);
}