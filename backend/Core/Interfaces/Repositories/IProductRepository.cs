using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IProductRepository : ISingleReadable<Product, Guid>
{
    Task<Result<List<Product>>> GetAllProductsByCategoryAsync(string category);
}