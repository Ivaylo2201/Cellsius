using Application.CQRS.Brands.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Brands.Handlers;

public class ListBrandsQueryHandler(IBrandRepository brandRepository) : IRequestHandler<ListBrandsQuery, Result<List<Brand>>>
{
    public async Task<Result<List<Brand>>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
    {
        var categoriesResult = await brandRepository.GetAllAsync();
        return Result.Success(categoriesResult.Value);
    }
}