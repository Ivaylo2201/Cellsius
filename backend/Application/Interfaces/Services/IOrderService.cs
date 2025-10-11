using Backend.Domain.Abstractions;
using Backend.Domain.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<Result> MarkItemsInUsersCartAsOrderedAsync(int userId, Order order);
}