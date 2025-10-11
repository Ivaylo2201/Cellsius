using Backend.Domain.Abstractions;

namespace Backend.Domain.Interfaces.Generic;

public interface ISingleReadable<T, in TIdentifier>
{
    Task<Result<T>> GetOneAsync(TIdentifier id);
}