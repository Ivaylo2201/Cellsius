using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Items.Queries;

public record GetItemQuery(int Id) : IRequest<Result<Item>>;