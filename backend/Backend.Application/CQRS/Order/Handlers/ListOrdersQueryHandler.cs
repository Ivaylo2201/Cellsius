using Backend.Application.CQRS.Order.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Order.Handlers;

using Order = Domain.Entities.Order;

public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery, Result<List<Order>>>
{
    public async Task<Result<List<Order>>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}