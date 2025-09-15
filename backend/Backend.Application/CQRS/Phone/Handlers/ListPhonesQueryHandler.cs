using Backend.Application.CQRS.Phone.Queries;
using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Phone.Handlers;

using Phone = Domain.Entities.Phone;

public class ListPhonesQueryHandler : IRequestHandler<ListPhonesQuery, Result<List<Phone>>>
{
    public async Task<Result<List<Phone>>> Handle(ListPhonesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}