using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Database.Repositories;

public class ReviewRepository(DatabaseContext context) : IReviewRepository
{
    public async Task<Result<Review>> CreateAsync(Review review)
    {
        var result = await context.Reviews.AddAsync(review);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }
}