using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Brand.Queries;

using Brand = Domain.Entities.Brand;

public record GetBrandQuery : IRequest<Result<Brand>>;