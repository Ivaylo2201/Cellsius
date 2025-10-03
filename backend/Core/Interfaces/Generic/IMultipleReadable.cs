using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface IMultipleReadable<T>
{
    Task<Result<List<T>>> GetAllAsync();
}