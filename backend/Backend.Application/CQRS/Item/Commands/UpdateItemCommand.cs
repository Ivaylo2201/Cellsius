using Backend.Application.DTOs.Item;
using MediatR;

namespace Backend.Application.CQRS.Item.Commands;

public record UpdateItemCommand(UpdateItemDto Dto) : IRequest<Unit>;