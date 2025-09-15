using Backend.Application.Interfaces.Generic;
using Backend.Domain.Abstractions;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories;

public interface IPhoneRepository : ICreatable<Phone>, ISingleReadable<Phone, Guid>, IMultipleReadable<Phone>
{
    Task<Result<List<Phone>>> GetFilteredPhonesAsync();
}