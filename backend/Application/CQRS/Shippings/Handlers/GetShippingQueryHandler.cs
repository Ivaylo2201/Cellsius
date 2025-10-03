using Application.CQRS.Shippings.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Shippings.Handlers;

public class GetShippingQueryHandler(IShippingRepository shippingRepository) : 
    IRequestHandler<GetShippingQuery, Result<Shipping>>
{
    public async Task<Result<Shipping>> Handle(GetShippingQuery request, CancellationToken cancellationToken)
    {
        var shipping = await shippingRepository.GetOneAsync(request.ShippingId);
        
        return shipping.IsSuccess
            ? Result.Success(shipping.Value)
            : Result.Failure<Shipping>(shipping.Error);
    }
}