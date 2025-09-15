using Backend.Application.CQRS.Color.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Color.Handlers;

using Color = Domain.Entities.Color;

public class GetColorQueryHandler : IRequestHandler<GetColorQuery, Result<Color>>
{
    public async Task<Result<Color>> Handle(GetColorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}