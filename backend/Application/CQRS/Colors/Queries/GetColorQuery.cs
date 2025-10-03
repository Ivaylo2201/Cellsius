using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Colors.Queries;

public record GetColorQuery(int ColorId) : IRequest<Result<Color>>;