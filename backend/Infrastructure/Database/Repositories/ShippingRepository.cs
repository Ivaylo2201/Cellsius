using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ShippingRepository(DatabaseContext context) : IShippingRepository
{
    public async Task<Result<Shipping>> GetOneAsync(int id)
    {
        var shipping = await context.Shippings.FindAsync(id);
        
        return shipping is null
            ? Result.Failure<Shipping>($"Shipping {id} not found.") 
            : Result.Success(shipping);
    }

    public async Task<Result<List<Shipping>>> GetAllAsync()
    {
        var shippings = await context.Shippings.ToListAsync();
        return Result.Success(shippings);
    }
}