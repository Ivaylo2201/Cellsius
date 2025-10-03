using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Models.Queries;

public record GetModelQuery(int ModelId) : IRequest<Result<Model>>;