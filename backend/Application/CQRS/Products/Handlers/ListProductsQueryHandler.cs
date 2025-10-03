using Application.CQRS.Products.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class ListProductsQueryHandler(IProductRepository productRepository) : 
    IRequestHandler<ListProductsQuery, Result<List<Product>>>
{
    public async Task<Result<List<Product>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAllProductsByCategoryAsync(request.Category);
        return Result.Success(result.Value);
    }
}