using Backend.Application.CQRS.Item.Commands;
using MediatR;

namespace Backend.Application.CQRS.Item.Handlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}