using Application.CQRS.Orders.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handlers;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUserRepository userRepository,
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOneAsync(request.Dto.UserId);
        
        if (!userResult.IsSuccess)
            return Result.Failure<Order>(userResult.Error);
        
        var order = new Order
        {
            User = userResult.Value
        };
        
        var orderResult = await orderRepository.CreateAsync(order);
        
        var markResult = await orderService.MarkItemsInUsersCartAsOrderedAsync(userResult.Value.Id, order);

        return markResult.IsSuccess
            ? Result.Success(orderResult.Value)
            : Result.Failure<Order>(markResult.Error);
    }
}