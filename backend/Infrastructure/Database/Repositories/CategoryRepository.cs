using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class CategoryRepository(DatabaseContext context) : ICategoryRepository
{
    public async Task<Result<List<Category>>> GetAllAsync()
    {
        var categories = await context.Categories.ToListAsync();
        return Result.Success(categories);
    }
}