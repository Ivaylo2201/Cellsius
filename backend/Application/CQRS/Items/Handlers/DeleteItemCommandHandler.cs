using Application.CQRS.Items.Commands;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class DeleteItemCommandHandler(IItemRepository itemRepository) : 
    IRequestHandler<DeleteItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await itemRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}