using Application.DTOs.Item;
using MediatR;

namespace Application.CQRS.Items.Commands;

public record UpdateItemCommand(UpdateItemDto Dto) : IRequest<Unit>;