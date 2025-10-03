using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DbSetExtensions
{
    public static async Task<T> Random<T>(this DbSet<T> dbSet) where T : class
    {
        return await dbSet.OrderBy(e => Guid.NewGuid()).FirstAsync();
    }
}