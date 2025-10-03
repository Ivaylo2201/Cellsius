using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Colors.Queries;

public record ListColorsQuery : IRequest<Result<List<Color>>>;