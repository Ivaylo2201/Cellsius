using Application.CQRS.Colors.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Colors.Handlers;

public class GetColorQueryHandler(IColorRepository colorRepository) : IRequestHandler<GetColorQuery, Result<Color>>
{
    public async Task<Result<Color>> Handle(GetColorQuery request, CancellationToken cancellationToken)
    {
        var color = await colorRepository.GetOneAsync(request.ColorId);
        
        return color.IsSuccess
            ? Result.Success(color.Value)
            : Result.Failure<Color>(color.Error);
    }
}