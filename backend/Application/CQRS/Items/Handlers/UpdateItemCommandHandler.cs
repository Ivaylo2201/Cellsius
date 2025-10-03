using Application.CQRS.Items.Commands;
using Application.Interfaces.Services;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class UpdateItemCommandHandler(IItemRepository itemRepository) :
    IRequestHandler<UpdateItemCommand, Unit>
{
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Dto.Item;

        item.Quantity = request.Dto.Quantity;
        await itemRepository.UpdateAsync(item);

        return Unit.Value;
    }
}