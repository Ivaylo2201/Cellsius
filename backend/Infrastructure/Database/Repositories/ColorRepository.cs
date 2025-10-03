using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ColorRepository(DatabaseContext context) : IColorRepository
{
    public async Task<Result<Color>> GetOneAsync(int id)
    {
        var color = await context.Colors.FindAsync(id);
        
        return color is null
            ? Result.Failure<Color>($"Color {id} not found.") 
            : Result.Success(color);
    }

    public async Task<Result<List<Color>>> GetAllAsync()
    {
        var colors = await context.Colors.ToListAsync();
        return Result.Success(colors);   
    }
}