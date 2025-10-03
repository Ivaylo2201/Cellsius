using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Brands.Queries;

public record GetBrandQuery(int BrandId) : IRequest<Result<Brand>>;