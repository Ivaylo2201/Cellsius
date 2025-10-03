using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Orders.Queries;

public record ListOrdersQuery(int UserId) : IRequest<Result<List<Order>>>;