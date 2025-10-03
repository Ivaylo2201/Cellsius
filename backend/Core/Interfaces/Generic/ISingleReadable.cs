using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface ISingleReadable<T, in TIdentifier>
{
    Task<Result<T>> GetOneAsync(TIdentifier id);
}