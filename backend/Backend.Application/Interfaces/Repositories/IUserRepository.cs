using Backend.Application.Interfaces.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories;

public interface IUserRepository : ISingleReadable<User, int>
{
    
}