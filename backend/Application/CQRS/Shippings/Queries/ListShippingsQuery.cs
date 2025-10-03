using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Shippings.Queries;

public record ListShippingsQuery : IRequest<Result<List<Shipping>>>;