using Backend.Application.CQRS.Brand.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Brand.Handlers;

using Brand = Domain.Entities.Brand;

public class ListBrandsQueryHandler : IRequestHandler<ListBrandsQuery, Result<List<Brand>>>
{
    public async Task<Result<List<Brand>>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}