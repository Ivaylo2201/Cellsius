using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Shippings.Queries;

public record GetShippingQuery(int ShippingId) : IRequest<Result<Shipping>>;