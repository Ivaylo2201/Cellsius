using Backend.Domain.Abstractions;

namespace Backend.Domain.Interfaces.Generic;

public interface IDeletable<in T>
{
    Task<Result> DeleteAsync(T id);
}