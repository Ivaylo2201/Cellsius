using Application.CQRS.Reviews.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Reviews.Handlers;

public class CreateReviewCommandHandler(IReviewRepository reviewRepository) : IRequestHandler<CreateReviewCommand, Result<Review>>
{
    public async Task<Result<Review>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            Rating = request.Dto.Rating,
            UserId = request.Dto.UserId,
            Comment = request.Dto.Comment,
            ProductId = request.Dto.ProductId,
        };
        
        return await reviewRepository.CreateAsync(review);
    }
}