using Application.CQRS.Shippings.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Shippings.Handlers;

public class ListShippingsQueryHandler(IShippingRepository shippingRepository) : IRequestHandler<ListShippingsQuery, Result<List<Shipping>>>
{
    public async Task<Result<List<Shipping>>> Handle(ListShippingsQuery request, CancellationToken cancellationToken)
    {
        var shippings = await shippingRepository.GetAllAsync();
        return Result.Success(shippings.Value);
    }
}