using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Order.Queries;

using Order = Domain.Entities.Order;

public record ListOrdersQuery : IRequest<Result<List<Order>>>;