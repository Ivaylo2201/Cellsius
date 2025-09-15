using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Abstractions;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ItemRepository(DatabaseContext context) : IItemRepository
{
    public async Task<Result<bool>> UpdateAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Item>> CreateAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> DeleteAsync(Item id)
    {
        throw new NotImplementedException();
    }

    public async Task MarkItemsAsOrderedAsync(Cart cart, Order order)
    {
        await context.Items
            .Where(item => item.CartId == cart.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(item => item.CartId, null!)
                .SetProperty(item => item.OrderId, order.Id)
            );


        await context.SaveChangesAsync();
    }
}