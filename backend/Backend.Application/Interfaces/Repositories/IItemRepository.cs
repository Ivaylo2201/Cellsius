using Backend.Application.Interfaces.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories;

public interface IItemRepository : IUpdatable<Item>, ICreatable<Item>, IDeletable<Item>
{
    Task MarkItemsAsOrderedAsync(Cart cart, Order order);
}