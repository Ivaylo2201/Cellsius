using Application.CQRS.Carts.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Carts.Handlers;

public class GetCartQueryHandler(ICartRepository cartRepository) :
    IRequestHandler<GetCartQuery, Result<Cart>>
{
    public async Task<Result<Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var result = await cartRepository.GetOneByUserIdAsync(request.UserId);
        
        return result.IsSuccess
            ? Result.Success(result.Value)
            : Result.Failure<Cart>(result.Error);
    }
}