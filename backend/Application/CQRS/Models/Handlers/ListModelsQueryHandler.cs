using Application.CQRS.Models.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Models.Handlers;

public class ListModelsQueryHandler(IModelRepository modelRepository) : IRequestHandler<ListModelsQuery, Result<List<Model>>>
{
    public async Task<Result<List<Model>>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
    {
        var models = await modelRepository.GetAllAsync();
        return Result.Success(models.Value);
    }
}