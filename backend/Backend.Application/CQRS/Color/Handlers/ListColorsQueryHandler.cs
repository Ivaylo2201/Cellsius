using Backend.Application.CQRS.Color.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Color.Handlers;

using Color = Domain.Entities.Color;

public class ListColorsQueryHandler : IRequestHandler<ListColorsQuery, Result<List<Color>>>
{
    public async Task<Result<List<Color>>> Handle(ListColorsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}