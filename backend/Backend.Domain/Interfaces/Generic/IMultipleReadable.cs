using Backend.Domain.Abstractions;

namespace Backend.Domain.Interfaces.Generic;

public interface IMultipleReadable<T>
{
    Task<Result<List<T>>> GetAllAsync();
}