using Application.CQRS.Products.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class GetProductQueryHandler(IProductRepository productRepository) : 
    IRequestHandler<GetProductQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetOneAsync(request.ProductId);

        return result.IsSuccess
            ? Result.Success(result.Value)
            : Result.Failure<Product>(result.Error);
    }
}