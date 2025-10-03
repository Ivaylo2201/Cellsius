using Application.DTOs.Review;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Reviews.Commands;

public record CreateReviewCommand(CreateReviewDto Dto) : IRequest<Result<Review>>;