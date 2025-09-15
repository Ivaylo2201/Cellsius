using Backend.Application.Interfaces.Generic;
using Backend.Domain.Abstractions;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories;

public interface IBrandRepository : ISingleReadable<Brand, int>, IMultipleReadable<Brand>, ICreatable<Brand>
{
    Task<Result<List<Brand>>> GetAllByNameAsync(string brandName);
}