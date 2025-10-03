using Application.CQRS.Brands.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Brands.Handlers;

public class GetBrandQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetBrandQuery, Result<Brand>>
{
    public async Task<Result<Brand>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetOneAsync(request.BrandId);
        
        return brand.IsSuccess
            ? Result.Success(brand.Value)
            : Result.Failure<Brand>(brand.Error);
    }
}