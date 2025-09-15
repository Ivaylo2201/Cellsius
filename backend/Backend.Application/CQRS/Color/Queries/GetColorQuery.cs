using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Color.Queries;

using Color = Domain.Entities.Color;

public record GetColorQuery : IRequest<Result<Color>>;