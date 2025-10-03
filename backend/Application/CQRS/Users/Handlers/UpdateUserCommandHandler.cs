using Application.CQRS.Users.Commands;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : 
    IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.Dto.User;
        
        user.PhoneNumber = request.Dto.PhoneNumber;
        user.Password = request.Dto.Password;
        await userRepository.UpdateAsync(user);
        
        return Unit.Value;
    }
}