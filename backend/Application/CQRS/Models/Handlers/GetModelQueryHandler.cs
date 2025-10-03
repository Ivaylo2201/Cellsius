using Application.CQRS.Models.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Models.Handlers;

public class GetModelQueryHandler(IModelRepository modelRepository) : IRequestHandler<GetModelQuery, Result<Model>>
{
    public async Task<Result<Model>> Handle(GetModelQuery request, CancellationToken cancellationToken)
    {
        var model = await modelRepository.GetOneAsync(request.ModelId);

        return model.IsSuccess 
            ? Result.Failure<Model>(model.Error) 
            : Result.Success(model.Value);
    }
}