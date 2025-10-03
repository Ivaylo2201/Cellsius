using Application.DTOs.Item;
using Core.Abstractions;
using MediatR;
using Core.Entities;

namespace Application.CQRS.Items.Commands;

public record CreateItemCommand(CreateItemDto Dto) : IRequest<Result<Item>>;