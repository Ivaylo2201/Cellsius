using Application.CQRS.Items.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class GetItemQueryHandler(IItemRepository itemRepository) 
    : IRequestHandler<GetItemQuery, Result<Item>>
{
    public async Task<Result<Item>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var result = await itemRepository.GetOneAsync(request.Id);

        return result.IsSuccess
            ? Result.Success(result.Value)
            : Result.Failure<Item>(result.Error);
    }
}