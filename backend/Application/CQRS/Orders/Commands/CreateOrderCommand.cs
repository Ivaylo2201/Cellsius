using Application.DTOs.Order;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Orders.Commands;

public record CreateOrderCommand(CreateOrderDto Dto) : IRequest<Result<Order>>;