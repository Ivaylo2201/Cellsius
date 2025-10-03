using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class OrderRepository(DatabaseContext context) : IOrderRepository
{
    public async Task<Result<List<Order>>> GetAllOrdersForUserAsync(int userId)
    {
        var items = await context.Orders
            .Include(o => o.Items)
                .ThenInclude(i => i.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();
        
        return Result.Success(items);
    }

    public async Task<Result<Order>> CreateAsync(Order order)
    {
        var result = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }
}