using Backend.Application.DTOs.Item;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Item.Commands;

using Item = Domain.Entities.Item;

public record CreateItemCommand(CreateItemDto Dto) : IRequest<Result<Item>>;