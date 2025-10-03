using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IItemRepository : 
    ICreatable<Item>, 
    IUpdatable<Item>, 
    IDeletable<int>, 
    ISingleReadable<Item, int>;