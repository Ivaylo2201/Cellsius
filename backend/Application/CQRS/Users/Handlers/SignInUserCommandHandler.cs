using Application.CQRS.Users.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class SignInUserCommandHandler(IAuthenticationService authenticationService) :
    IRequestHandler<SignInUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        var (isSignedUp, user) = await authenticationService
            .IsSignedUpAsync(request.Dto.Username, request.Dto.Password);
        
        return isSignedUp
            ? Result.Success(user)
            : Result.Failure<User>("Invalid credentials provided.");
    }
}