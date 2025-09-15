using Backend.Application.CQRS.Order.Commands;
using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Order.Handlers;

using Order = Domain.Entities.Order;

public class CreateOrderCommandHandler(
    IUserRepository userRepository,
    IShippingRepository shippingRepository,
    IOrderRepository orderRepository,
    IItemRepository itemRepository) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOneByIdAsync(request.Dto.UserId);

        if (!userResult.IsSuccess)
            return Result.Failure<Order>(userResult.Error);
        
        var shippingResult = await shippingRepository.GetOneByIdAsync(request.Dto.ShippingId);
        
        if (!shippingResult.IsSuccess)
            return Result.Failure<Order>(shippingResult.Error);
        
        var order = new Order
        {
            User = userResult.Value,
            Shipping = shippingResult.Value,
            Total = userResult.Value.Cart.Items.Sum(x => x.Price) + shippingResult.Value.Cost
        };
        
        var orderResult = await orderRepository.CreateAsync(order);
        
        await itemRepository.MarkItemsAsOrderedAsync(userResult.Value.Cart, orderResult.Value);
        
        return orderResult.IsSuccess 
            ? Result.Success(orderResult.Value) 
            : Result.Failure<Order>(orderResult.Error);
    }
}