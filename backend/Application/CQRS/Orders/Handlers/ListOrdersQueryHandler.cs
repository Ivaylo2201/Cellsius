using Application.CQRS.Orders.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handlers;

public class ListOrdersQueryHandler(
    IOrderRepository orderRepository) : 
    IRequestHandler<ListOrdersQuery, Result<List<Order>>>
{
    public async Task<Result<List<Order>>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        var ordersResult = await orderRepository.GetAllOrdersForUserAsync(request.UserId);
        return Result.Success(ordersResult.Value);
    }
}