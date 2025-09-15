using Backend.Application.CQRS.Item.Commands;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Item.Handlers;

using Item = Domain.Entities.Item;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Result<Item>>
{
    public async Task<Result<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}