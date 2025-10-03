using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record GetProductQuery(Guid ProductId) : IRequest<Result<Product>>;