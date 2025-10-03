using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Models.Queries;

public record ListModelsQuery : IRequest<Result<List<Model>>>;