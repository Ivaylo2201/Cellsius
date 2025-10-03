using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class OrderService(DatabaseContext context, ICartRepository cartRepository) : IOrderService
{
    public async Task<Result> MarkItemsInUsersCartAsOrderedAsync(int userId, Order order)
    {
        var result = await cartRepository.GetItemsFromUsersCartAsync(userId);
        
        if (!result.IsSuccess)
            return Result.Failure(result.Error);
        
        foreach (var item in result.Value)
        {
            item.Cart = null;
            item.Order = order;
        }

        await context.SaveChangesAsync();
        return Result.Success();
    }
}