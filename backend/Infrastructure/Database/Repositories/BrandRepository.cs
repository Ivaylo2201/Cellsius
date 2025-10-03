using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class BrandRepository(DatabaseContext context) : IBrandRepository
{
    public async Task<Result<Brand>> GetOneAsync(int id)
    {
        var brand = await context.Brands.FindAsync(id);
        
        return brand is null
            ? Result.Failure<Brand>($"Brand {id} not found.") 
            : Result.Success(brand);
    }

    public async Task<Result<List<Brand>>> GetAllAsync()
    {
        var brands = await context.Brands.ToListAsync();
        return Result.Success(brands);
    }
}