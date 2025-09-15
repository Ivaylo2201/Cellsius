using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Brand.Queries;

using Brand = Domain.Entities.Brand;

public record ListBrandsQuery : IRequest<Result<List<Brand>>>;
