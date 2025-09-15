using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQueryHandler : IRequestHandler<GetShippingQuery, Result<Shipping>>
{
    public async Task<Result<Shipping>> Handle(GetShippingQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}