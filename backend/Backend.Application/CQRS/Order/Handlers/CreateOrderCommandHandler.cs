using Backend.Application.CQRS.Order.Commands;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Order.Handlers;

using Order = Domain.Entities.Order;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}