using Backend.Application.CQRS.Brand.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Brand.Handlers;

using Brand = Domain.Entities.Brand;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Result<Brand>>
{
    public async Task<Result<Brand>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}