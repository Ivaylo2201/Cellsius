using MediatR;

namespace Application.CQRS.Items.Commands;

public record DeleteItemCommand(int Id) : IRequest<Unit>;