using Backend.Domain.Abstractions;

namespace Backend.Application.Interfaces.Generic;

public interface IUpdatable<in TEntity>
{
    Task<Result<bool>> UpdateAsync(TEntity item);
}