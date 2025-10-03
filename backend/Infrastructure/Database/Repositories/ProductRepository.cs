using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ProductRepository(DatabaseContext context) : IProductRepository
{
    public async Task<Result<List<Product>>> GetAllProductsByCategoryAsync(string category)
    {
        var products = await context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
            .Where(p => p.Category.CategoryName == category)
            .OrderBy(p => p.ProductName)
            .ToListAsync();
        
        return Result.Success(products);
    }

    public async Task<Result<Product>> GetOneAsync(Guid id)
    {
        var product = await context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
            .SingleOrDefaultAsync(p => p.Id == id);

        return product is null
            ? Result.Failure<Product>($"Product {id} not found.") 
            : Result.Success(product);
    }
}