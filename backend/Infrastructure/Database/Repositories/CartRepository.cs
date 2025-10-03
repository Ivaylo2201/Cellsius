using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class CartRepository(DatabaseContext context) : ICartRepository
{
    public async Task<Result<Cart>> CreateAsync(Cart item)
    {
        var result = await context.Carts.AddAsync(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<Cart>> GetOneByUserIdAsync(int userId)
    {
        var cart = await context.Carts
            .Include(c => c.User)
            .Include(c => c.Items)
                .ThenInclude(i => i.Product)
            .SingleOrDefaultAsync(c => c.UserId == userId);
        
        return cart == null
            ? Result.Failure<Cart>($"User #{userId}'s cart was not found.") 
            : Result.Success(cart);
    }
    
    public async Task<Result<List<Item>>> GetItemsFromUsersCartAsync(int userId)
    {
        var user = await context.Users.Include(u => u.Cart).SingleOrDefaultAsync(u => u.Id == userId);

        if (user is null)
            return Result.Failure<List<Item>>($"Multiple users or no user with id {userId} found.");
        
        var items = await context.Items.Where(i => i.CartId == user.Cart.Id).ToListAsync();
        return Result.Success(items);
    }

    public async Task<Result> UpdateAsync(Cart cart)
    {
        context.Carts.Update(cart);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}