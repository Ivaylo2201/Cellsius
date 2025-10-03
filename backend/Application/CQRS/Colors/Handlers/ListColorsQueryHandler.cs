using Application.CQRS.Colors.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Colors.Handlers;

public class ListColorsQueryHandler(IColorRepository colorRepository) : IRequestHandler<ListColorsQuery, Result<List<Color>>>
{
    public async Task<Result<List<Color>>> Handle(ListColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await colorRepository.GetAllAsync();
        return Result.Success(colors.Value);
    }
}