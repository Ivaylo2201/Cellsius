using Backend.Application.DTOs.Order;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Order.Commands;

using Order = Domain.Entities.Order;

public record CreateOrderCommand(CreateOrderDto Dto) : IRequest<Result<Order>>;