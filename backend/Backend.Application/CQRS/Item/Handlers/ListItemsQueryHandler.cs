using Backend.Application.CQRS.Item.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Item.Handlers;

using Item = Domain.Entities.Item;

public class ListItemsQueryHandler : IRequestHandler<ListItemsQuery, Result<List<Item>>>
{
    public async Task<Result<List<Item>>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}