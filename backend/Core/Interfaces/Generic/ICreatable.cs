using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface ICreatable<T>
{
    Task<Result<T>> CreateAsync(T item);
}