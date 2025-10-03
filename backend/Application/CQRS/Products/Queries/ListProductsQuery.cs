using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record ListProductsQuery(string Category) : IRequest<Result<List<Product>>>;