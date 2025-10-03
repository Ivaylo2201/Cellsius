using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Carts.Queries;

public record GetCartQuery(int UserId) : IRequest<Result<Cart>>;