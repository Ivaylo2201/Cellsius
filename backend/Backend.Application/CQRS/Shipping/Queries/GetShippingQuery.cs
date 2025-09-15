using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public record GetShippingQuery : IRequest<Result<Shipping>>;