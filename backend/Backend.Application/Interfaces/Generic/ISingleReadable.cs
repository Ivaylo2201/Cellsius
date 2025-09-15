using Backend.Domain.Abstractions;

namespace Backend.Application.Interfaces.Generic;

public interface ISingleReadable<TEntity, in TIdentifier>
{
    Task<Result<TEntity>> GetOneByIdAsync(TIdentifier id);
}