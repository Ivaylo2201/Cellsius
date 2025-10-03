using Application.CQRS.Users.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class CreateUserCommandHandler(IUserRepository userRepository, IAuthenticationService authenticationService) : 
    IRequestHandler<CreateUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await authenticationService.IsUsernameTakenAsync(request.Dto.Username))
            return Result.Failure<User>("Username already taken.");
        
        var user = new User
        {
            Username = request.Dto.Username,
            PhoneNumber = request.Dto.PhoneNumber,
            Password = request.Dto.Password,
        };
        
        var result = await userRepository.CreateAsync(user);
        return Result.Success(result.Value); 
    }
}