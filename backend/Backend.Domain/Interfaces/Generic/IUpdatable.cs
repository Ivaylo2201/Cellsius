using Backend.Domain.Abstractions;

namespace Backend.Domain.Interfaces.Generic;

public interface IUpdatable<in T>
{
    Task<Result> UpdateAsync(T item);
}