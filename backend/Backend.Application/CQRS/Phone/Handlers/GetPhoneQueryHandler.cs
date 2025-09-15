using Backend.Application.CQRS.Phone.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Phone.Handlers;

using Phone = Domain.Entities.Phone;

public class GetPhoneQueryHandler : IRequestHandler<GetPhoneQuery, Result<Phone>>
{
    public async Task<Result<Phone>> Handle(GetPhoneQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}