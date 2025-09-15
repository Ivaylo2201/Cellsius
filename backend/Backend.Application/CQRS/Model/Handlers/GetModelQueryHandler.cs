using Backend.Application.CQRS.Model.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Model.Handlers;

using Model = Domain.Entities.Model;

public class GetModelQueryHandler : IRequestHandler<GetModelQuery, Result<Model>>
{
    public async Task<Result<Model>> Handle(GetModelQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}