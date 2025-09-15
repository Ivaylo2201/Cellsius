using Backend.Application.CQRS.Cart.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Cart.Handlers;

using Cart = Domain.Entities.Cart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Result<Cart>>
{
    public async Task<Result<Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}