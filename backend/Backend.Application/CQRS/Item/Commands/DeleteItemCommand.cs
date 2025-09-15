using MediatR;

namespace Backend.Application.CQRS.Item.Commands;

public record DeleteItemCommand(Guid Id) : IRequest<Unit>;