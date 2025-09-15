using Backend.Application.CQRS.Model.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Model.Handlers;

using Model = Domain.Entities.Model;

public class ListModelsQueryHandler : IRequestHandler<ListModelsQuery, Result<List<Model>>>
{
    public async Task<Result<List<Model>>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}