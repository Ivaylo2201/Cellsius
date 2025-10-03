using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface IDeletable<in T>
{
    Task<Result> DeleteAsync(T id);
}