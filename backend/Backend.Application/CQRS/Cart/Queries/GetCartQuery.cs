using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Cart.Queries;

using Cart = Domain.Entities.Cart;

public record GetCartQuery : IRequest<Result<Cart>>;