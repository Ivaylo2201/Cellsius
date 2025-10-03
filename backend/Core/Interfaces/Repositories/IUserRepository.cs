using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IUserRepository :
    ICreatable<User>,
    ISingleReadable<User, int>,
    IUpdatable<User>
{
    Task<Result<User>> GetOneAsync(string username);
}