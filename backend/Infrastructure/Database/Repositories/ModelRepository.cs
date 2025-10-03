using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ModelRepository(DatabaseContext context) : IModelRepository
{
    public async Task<Result<Model>> GetOneAsync(int id)
    {
        var model = await context.Models.FindAsync(id);
        
        return model is null
            ? Result.Failure<Model>($"Model {id} not found.") 
            : Result.Success(model);
    }

    public async Task<Result<List<Model>>> GetAllAsync()
    {
        var models = await context.Models.ToListAsync();
        return Result.Success(models);
    }
}