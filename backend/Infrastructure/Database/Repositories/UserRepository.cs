using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<Result<User>> CreateAsync(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var result = await context.Users.AddAsync(user);
        
        var cart = new Cart { User = result.Entity };
        await context.Carts.AddAsync(cart);
        
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }
    
    public async Task<Result> UpdateAsync(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<User>> GetOneAsync(int id)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
        
        return user is null 
            ? Result.Failure<User>($"User {id} not found")
            : Result.Success(user);
    }
    
    public async Task<Result<User>> GetOneAsync(string username)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username);
        
        return user is null 
            ? Result.Failure<User>($"User {username} not found")
            : Result.Success(user);
    }
}