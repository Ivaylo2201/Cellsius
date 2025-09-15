using Backend.Domain.Abstractions;

namespace Backend.Application.Interfaces.Generic;

public interface ICreatable<TEntity>
{
    Task<Result<TEntity>> CreateAsync(TEntity item);
}