using Backend.Application.Interfaces.Generic;
using Backend.Domain.Abstractions;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories;

public interface IOrderRepository : ICreatable<Order>
{
    Task<Result<List<Order>>> GetOrdersByUserIdAsync(int userId);
}