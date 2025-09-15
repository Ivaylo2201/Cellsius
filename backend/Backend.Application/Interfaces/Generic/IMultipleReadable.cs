using Backend.Domain.Abstractions;

namespace Backend.Application.Interfaces.Generic;

public interface IMultipleReadable<TEntity>
{
    Task<Result<List<TEntity>>> GetAllAsync();
}