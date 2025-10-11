using Backend.Domain.Abstractions;

namespace Backend.Domain.Interfaces.Generic;

public interface ICreatable<T>
{
    Task<Result<T>> CreateAsync(T item);
}