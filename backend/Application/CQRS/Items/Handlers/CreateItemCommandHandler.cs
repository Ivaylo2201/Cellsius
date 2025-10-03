using Application.CQRS.Items.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class CreateItemCommandHandler(IItemRepository itemRepository) 
    : IRequestHandler<CreateItemCommand, Result<Item>>
{
    public async Task<Result<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var itemPrice = request.Dto.Quantity * request.Dto.Product.Price;
        
        var item = new Item
        {
            Product = request.Dto.Product,
            Quantity = request.Dto.Quantity,
            Cart = request.Dto.Cart
        };

        return await itemRepository.CreateAsync(item);
    }
}