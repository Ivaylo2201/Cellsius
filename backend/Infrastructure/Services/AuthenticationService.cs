using Application.Interfaces.Services;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<(bool, User)> IsSignedUpAsync(string username, string password)
    {
        var userResult = await userRepository.GetOneAsync(username);

        if (!userResult.IsSuccess || !BCrypt.Net.BCrypt.Verify(password, userResult.Value.Password))
            return (false, userResult.Value);

        return (true, userResult.Value);
    }
    
    public async Task<bool> IsUsernameTakenAsync(string username)
    {
        var userResult = await userRepository.GetOneAsync(username);
        return userResult.IsSuccess;
    }
}