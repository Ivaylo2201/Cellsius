using Core.Abstractions;
using Core.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<Result> MarkItemsInUsersCartAsOrderedAsync(int userId, Order order);
}