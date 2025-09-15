using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class ListShippingsQueryHandler : IRequestHandler<ListShippingsQuery, Result<List<Shipping>>>
{
    public async Task<Result<List<Shipping>>> Handle(ListShippingsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}