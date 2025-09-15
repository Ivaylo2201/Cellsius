using Backend.Domain.Abstractions;
using MediatR;

namespace Backend.Application.CQRS.Phone.Queries;

using Phone = Domain.Entities.Phone;

public record GetPhoneQuery : IRequest<Result<Phone>>;