using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Item.Queries;

using Item = Domain.Entities.Item;

public record ListItemsQuery : IRequest<Result<List<Item>>>;