using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Phone.Queries;

using Phone = Domain.Entities.Phone;

public record ListPhonesQuery(FilterCriteria FilterCriteria) : IRequest<Result<List<Phone>>>;

public record FilterCriteria
{
    public string? Search { get; init; }
    public string? Brand { get; init; }
    public string? Models { get; init; }
    public string? Color { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
}
