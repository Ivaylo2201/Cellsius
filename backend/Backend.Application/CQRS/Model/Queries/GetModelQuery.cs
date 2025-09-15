using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Model.Queries;

using Model = Domain.Entities.Model;

public record GetModelQuery : IRequest<Result<Model>>;