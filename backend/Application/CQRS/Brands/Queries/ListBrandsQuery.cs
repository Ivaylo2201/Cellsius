using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Brands.Queries;

public record ListBrandsQuery : IRequest<Result<List<Brand>>>;