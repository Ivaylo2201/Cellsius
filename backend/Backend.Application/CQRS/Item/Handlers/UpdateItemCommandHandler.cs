using Backend.Application.CQRS.Item.Commands;
using MediatR;

namespace Backend.Application.CQRS.Item.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
{
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}